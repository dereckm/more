using More.Core;
using More.Strings.Models;

namespace More.Strings.Calculators;

public class DamerauLevenshteinDistanceCalculator : ICalculator<StringComparisonInput, int>
{
    public int Calculate(StringComparisonInput input)
    {
        var source = input.Source;
        var target = input.Target;
        var sourceLength = source.Length;
        var targetLength = target.Length;

        if (sourceLength == 0)
            return targetLength;
        if (targetLength == 0)
            return sourceLength;

        var distanceMatrix = new int[sourceLength + 1, targetLength + 1];
        for (var i = 0; i <= sourceLength; i++)
            distanceMatrix[i, 0] = i;
        for (var j = 0; j <= targetLength; j++)
            distanceMatrix[0, j] = j;

        for (var i = 1; i <= sourceLength; i++)
        {
            for (var j = 1; j <= targetLength; j++)
            {
                var cost = source[i - 1] == target[j - 1] ? 0 : 1;
                var deletion = distanceMatrix[i - 1, j] + 1;
                var insertion = distanceMatrix[i, j - 1] + 1;
                var substitution = distanceMatrix[i - 1, j - 1] + cost;

                distanceMatrix[i, j] = Math.Min(Math.Min(deletion, insertion), substitution);

                if (i > 1 && j > 1 && source[i - 1] == target[j - 2] && source[i - 2] == target[j - 1])
                {
                    distanceMatrix[i, j] = Math.Min(distanceMatrix[i, j], distanceMatrix[i - 2, j - 2] + cost);
                }
            }
        }

        return distanceMatrix[sourceLength, targetLength];
    }
}