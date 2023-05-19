// See https://aka.ms/new-console-template for more information

using More.Strings;
using More.Strings.Calculators;
using More.Strings.Models;

var distanceCalculator = new HammingDistanceCalculator();
Console.WriteLine(distanceCalculator.Calculate(new StringDistanceInput("climax", "volmax")));
Console.WriteLine(distanceCalculator.Calculate(new StringDistanceInput("Ram", "Rom")));
Console.WriteLine(distanceCalculator.Calculate(new StringDistanceInput("Mam", "Mom")));