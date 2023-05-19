using FluentAssertions;
using More.Strings.Calculators;
using More.Strings.Models;
using NUnit.Framework;

namespace More.Strings.Tests.Calculators;

[TestFixture]
public class LevenshteinDistanceCalculatorTests
{
    private LevenshteinDistanceCalculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new LevenshteinDistanceCalculator();
    }

    [Test]
    public void Calculate_WhenSourceAndTargetAreEqual_ShouldReturnZero()
    {
        // Arrange
        var input = new StringDistanceInput("hello", "hello");

        // Act
        var distance = _calculator.Calculate(input);

        // Assert
        distance.Should().Be(0);
    }

    [Test]
    public void Calculate_WhenSourceIsEmpty_ShouldReturnTargetLength()
    {
        // Arrange
        var input = new StringDistanceInput("", "world");

        // Act
        var distance = _calculator.Calculate(input);

        // Assert
        distance.Should().Be(5);
    }

    [Test]
    public void Calculate_WhenTargetIsEmpty_ShouldReturnSourceLength()
    {
        // Arrange
        var input = new StringDistanceInput("hello", "");

        // Act
        var distance = _calculator.Calculate(input);

        // Assert
        distance.Should().Be(5);
    }

    [Test]
    public void Calculate_WhenSourceAndTargetHaveDifferentCharacters_ShouldReturnCorrectDistance()
    {
        // Arrange
        var input = new StringDistanceInput("kitten", "sitting");

        // Act
        var distance = _calculator.Calculate(input);

        // Assert
        distance.Should().Be(3);
    }

    [Test]
    public void Calculate_WhenSourceAndTargetAreCompletelyDifferent_ShouldReturnMaxLength()
    {
        // Arrange
        var input = new StringDistanceInput("abc", "def");

        // Act
        var distance = _calculator.Calculate(input);

        // Assert
        distance.Should().Be(3);
    }
}