﻿using More.Core;
using More.Strings.Models;

namespace More.Strings.Calculations;

public class HammingDistanceCalculator : ICalculator<StringComparisonInput, int>
{
    public int Calculate(StringComparisonInput input)
    {
        var a = input.Source;
        var b = input.Target;
        if (a.Length != b.Length) throw new ArgumentException($"Strings should be of equal length - found A with length: {a.Length} and B with length: {b.Length}");
        if (ReferenceEquals(a, b)) return 0;
        var distance = 0;
        for (var i = 0; i < a.Length; i++)
        {
            distance += Convert.ToUInt16(a[i] != b[i]);
        }

        return distance;
    }
}