﻿// See https://aka.ms/new-console-template for more information

using More.Strings;
using More.Strings.Calculations;
using More.Strings.Models;

var distanceCalculator = new HammingDistanceCalculator();
Console.WriteLine(distanceCalculator.Calculate(new StringComparisonInput("climax", "volmax")));
Console.WriteLine(distanceCalculator.Calculate(new StringComparisonInput("Ram", "Rom")));
Console.WriteLine(distanceCalculator.Calculate(new StringComparisonInput("Mam", "Mom")));