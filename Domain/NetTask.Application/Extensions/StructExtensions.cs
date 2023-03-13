namespace NetTask.Application.Extensions;
internal class StructExtensions
{
    /// <summary>
    /// Convert enum values to dictionary.
    /// </summary>
    /// <typeparam name="T">Enum type.</typeparam>
    /// <returns>A dictionary of the enum's keys and values.</returns>
    /// <exception cref="ArgumentException">Thrown if <typeparamref name="T"/> is not an enum.</exception>
    public static Dictionary<int, string> ToDictionary<T>() where T : struct
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("T is not an Enum type");

        return Enum.GetValues(typeof(T))
            .Cast<object>()
            .ToDictionary(k => (int)k, v => ((Enum)v).ToString());
    }
}
