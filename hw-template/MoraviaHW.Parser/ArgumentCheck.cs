namespace MoraviaHW.Parser;

public static class ArgumentCheck
{
    public static void IsNotNull(object argument, string argumentName, string message = null)
    {
        if (argument == null)
        {
            throw new ArgumentNullException(message ?? $"Argument '{argumentName ?? "<null>"}' is null.");
        }
    }

    public static void IsNotNullOrEmpty(string argument, string argumentName, string message = null)
    {
        if (string.IsNullOrEmpty(argument))
        {
            throw new ArgumentException(message ?? $"Argument '{argumentName ?? "<null>"}' is null or empty.");
        }
    }

    public static void IsNotNullOrWhiteSpace(string argument, string argumentName, string message = null)
    {
        if (string.IsNullOrWhiteSpace(argument))
        {
            throw new ArgumentException(message ?? $"Argument '{argumentName ?? "<null>"}' is null, empty or white space.");
        }
    }
}