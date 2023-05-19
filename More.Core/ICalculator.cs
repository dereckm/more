namespace More.Core;

public interface ICalculator<in TIn, out TOut>
{
    TOut Calculate(TIn input);
}