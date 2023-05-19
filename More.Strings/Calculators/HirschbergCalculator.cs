using More.Core;
using More.Strings.Models;

namespace More.Strings.Calculators;

public class HirschbergCalculator : ICalculator<StringComparisonInput, int>
{
    private readonly ICalculator<StringComparisonInput, int> _needlemanWunschCalculator;

    public HirschbergCalculator(ICalculator<StringComparisonInput, int> needlemanWunschCalculator)
    {
        _needlemanWunschCalculator = needlemanWunschCalculator;
    }

    public int Calculate(StringComparisonInput input)
    {
        var source = input.Source;
        var target = input.Target;

        return HirschbergAlgorithm(source, target);
    }

    private int HirschbergAlgorithm(string source, string target)
    {
        var sourceLength = source.Length;
        var targetLength = target.Length;

        if (sourceLength == 0)
            return targetLength;
        if (targetLength == 0)
            return sourceLength;
        if (source.Equals(target))
            return 0;

        if (sourceLength == 1 || targetLength == 1)
            return _needlemanWunschCalculator.Calculate(new StringComparisonInput(source, target));

        var midSource = sourceLength / 2;

        var upperSource = source[..midSource];
        var lowerSource = source[midSource..];

        var upperTarget = target[..];
        var lowerTarget = target[..].Reverse().ToString();

        var upperDistances = ComputeDistances(upperSource, upperTarget);
        var lowerDistances = ComputeDistances(lowerSource, lowerTarget).Reverse().ToArray();

        var minDistance = int.MaxValue;
        for (var i = 0; i <= targetLength; i++)
        {
            var distance = upperDistances[i] + lowerDistances[i];
            minDistance = Math.Min(minDistance, distance);
        }

        return minDistance;
    }

    private int[] ComputeDistances(string source, string target)
    {
        var sourceLength = source.Length;
        var targetLength = target.Length;

        var previousDistances = new int[targetLength + 1];
        var currentDistances = new int[targetLength + 1];

        for (var j = 0; j <= targetLength; j++)
            previousDistances[j] = j;

        for (var i = 1; i <= sourceLength; i++)
        {
            currentDistances[0] = i;
            for (var j = 1; j <= targetLength; j++)
            {
                var substitutionCost = (source[i - 1] == target[j - 1]) ? 0 : 1;
                currentDistances[j] = Math.Min(Math.Min(previousDistances[j] + 1, currentDistances[j - 1] + 1),
                    previousDistances[j - 1] + substitutionCost);
            }
            Array.Copy(currentDistances, previousDistances, targetLength + 1);
        }

        return previousDistances;
    }
}

