namespace System;
public static class StringExtensions
{
    /// <summary>
    /// Splits pascal case strings and presents them separately <br/>
    /// Example: PascalCase <span>&#8594;</span> Pascal Case.
    /// </summary>
    /// <param name="value">String in pascal case.</param>
    /// <returns></returns>
    public static string SplitPascalCase(this string value)
    {
        var result = value.SelectMany((c, i) =>
                i != 0 &&
                char.IsUpper(c) &&
                !char.IsUpper(value[i - 1])
           ? new char[] { ' ', c }
           : new char[] { c });

        return new string(result.ToArray());
    }

}
