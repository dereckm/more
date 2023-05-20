using More.Core;
using More.Strings.Models;

namespace More.Strings.Calculations;

public class NeedlemanWunschCalculator : ICalculator<StringComparisonInput, int>
{
    public int Calculate(StringComparisonInput input)
    {
        var source = input.Source;
        var target = input.Target;
        var sourceLength = source.Length;
        var targetLength = target.Length;

        var distanceMatrix = new int[sourceLength + 1, targetLength + 1];

        for (var i = 0; i <= sourceLength; i++)
            distanceMatrix[i, 0] = i;

        for (var j = 0; j <= targetLength; j++)
            distanceMatrix[0, j] = j;

        for (var i = 1; i <= sourceLength; i++)
        {
            for (var j = 1; j <= targetLength; j++)
            {
                var substitutionCost = (source[i - 1] == target[j - 1]) ? 0 : 1;
                distanceMatrix[i, j] = Math.Min(Math.Min(distanceMatrix[i - 1, j] + 1, distanceMatrix[i, j - 1] + 1), distanceMatrix[i - 1, j - 1] + substitutionCost);
            }
        }

        return distanceMatrix[sourceLength, targetLength];
    }
}