using More.Core;
using More.Strings.Models;

namespace More.Strings.Calculations;

public class LevenshteinDistanceCalculator : ICalculator<StringComparisonInput, int>
{
    public int Calculate(StringComparisonInput input)
    {
        var sourceLength = input.Source.Length;
        var targetLength = input.Target.Length;
        var distanceMatrix = new int[sourceLength + 1, targetLength + 1];

        // Initialize the first row and column of the distance matrix
        for (var i = 0; i <= sourceLength; i++)
            distanceMatrix[i, 0] = i;
        for (var j = 0; j <= targetLength; j++)
            distanceMatrix[0, j] = j;

        // Compute the remaining distances
        for (var i = 1; i <= sourceLength; i++)
        {
            for (var j = 1; j <= targetLength; j++)
            {
                var cost = (input.Source[i - 1] == input.Target[j - 1]) ? 0 : 1;
                var deletion = distanceMatrix[i - 1, j] + 1;
                var insertion = distanceMatrix[i, j - 1] + 1;
                var substitution = distanceMatrix[i - 1, j - 1] + cost;

                distanceMatrix[i, j] = Math.Min(Math.Min(deletion, insertion), substitution);
            }
        }

        return distanceMatrix[sourceLength, targetLength];
        
    }
}