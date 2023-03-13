using FluentValidation;
using MediatR;

namespace NetTask.Application.Behaviours;

/// <summary>
/// Validation behaviour for MediatR.
/// </summary>
/// <typeparam name="TRequest"><see cref="Type"/> of the request.</typeparam>
/// <typeparam name="TResponse"><see cref="Type"/> of the response.</typeparam>
internal class ValidationBehaviour<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .SelectMany(result => result.Errors)
            .Where(failures => failures != null)
            .Select(failure => failure.ErrorMessage)
            .ToList();

        if (failures.Count != 0)
            throw new Exceptions.ValidationException(failures);

        return await next();
    }
}
