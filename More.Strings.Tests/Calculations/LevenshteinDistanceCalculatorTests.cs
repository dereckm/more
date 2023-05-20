using FluentAssertions;
using More.Strings.Calculations;
using More.Strings.Models;
using NUnit.Framework;

namespace More.Strings.Tests.Calculations;

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
        var input = new StringComparisonInput("hello", "hello");

        // Act
        var distance = _calculator.Calculate(input);

        // Assert
        distance.Should().Be(0);
    }

    [Test]
    public void Calculate_WhenSourceIsEmpty_ShouldReturnTargetLength()
    {
        // Arrange
        var input = new StringComparisonInput("", "world");

        // Act
        var distance = _calculator.Calculate(input);

        // Assert
        distance.Should().Be(5);
    }

    [Test]
    public void Calculate_WhenTargetIsEmpty_ShouldReturnSourceLength()
    {
        // Arrange
        var input = new StringComparisonInput("hello", "");

        // Act
        var distance = _calculator.Calculate(input);

        // Assert
        distance.Should().Be(5);
    }

    [Test]
    public void Calculate_WhenSourceAndTargetHaveDifferentCharacters_ShouldReturnCorrectDistance()
    {
        // Arrange
        var input = new StringComparisonInput("kitten", "sitting");

        // Act
        var distance = _calculator.Calculate(input);

        // Assert
        distance.Should().Be(3);
    }

    [Test]
    public void Calculate_WhenSourceAndTargetAreCompletelyDifferent_ShouldReturnMaxLength()
    {
        // Arrange
        var input = new StringComparisonInput("abc", "def");

        // Act
        var distance = _calculator.Calculate(input);

        // Assert
        distance.Should().Be(3);
    }
}