namespace More.Strings.Models;

public class StringComparisonInput
{
    public StringComparisonInput(string source, string target)
    {
        Source = source;
        Target = target;
    }

    public string Source { get; }
    public string Target { get; }
}