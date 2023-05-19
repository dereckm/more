using More.Strings.Calculators;
using More.Strings.Models;

namespace More.Strings.Tests.Calculators;

using NUnit.Framework;
using FluentAssertions;

[TestFixture]
public class HirschbergACalculatorTests
{
    private HirschbergCalculator _calculator;

    [SetUp]
    public void Setup()
    {
        var needlemanWunschCalculator = new NeedlemanWunschCalculator();
        _calculator = new HirschbergCalculator(needlemanWunschCalculator);
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