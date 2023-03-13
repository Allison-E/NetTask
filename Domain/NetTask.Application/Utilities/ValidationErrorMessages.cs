namespace NetTask.Application.Utilities;
internal static class ValidationErrorMessages
{
    internal const string ShouldNotBeNull = "{PropertyName} should not be null.";
    internal const string ShouldNotBeEmpty = "{PropertyName} should not be empty.";
    internal const string DateShouldBeInTheFuture = "{PropertyName} should be in the future.";

    internal static string ShouldBeInEnum<T>(T enumType) where T : Type
    {
        if (!enumType.IsEnum)
            throw new Exception($"{enumType.Name} is not an enum.");

        var enumValues = Enum.GetValuesAsUnderlyingType(enumType);
        var lowestValue = enumValues.GetValue(0);
        var highestValue = enumValues.GetValue(enumValues.Length - 1);

        return $"{{PropertyName}} should be between {lowestValue} and {highestValue}.";
    }

    internal static string ShouldBeGreaterThan(object value)
    {
        return $"{{PropertyName}} should be greater than {value}.";
    }
}
