namespace More.Strings.Models;

public class StringDistanceInput
{
    public StringDistanceInput(string source, string target)
    {
        Source = source;
        Target = target;
    }

    public string Source { get; }
    public string Target { get; }
}