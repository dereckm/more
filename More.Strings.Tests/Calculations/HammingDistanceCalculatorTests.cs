using System;
using FluentAssertions;
using More.Strings.Calculations;
using More.Strings.Models;
using NUnit.Framework;

namespace More.Strings.Tests.Calculations;

[TestFixture]
public class HammingDistanceCalculatorTests
{
    private HammingDistanceCalculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new HammingDistanceCalculator();
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
    public void Calculate_WhenSourceAndTargetAreDifferentByOneCharacter_ShouldReturnOne()
    {
        // Arrange
        var input = new StringComparisonInput("hello", "hella");

        // Act
        var distance = _calculator.Calculate(input);

        // Assert
        distance.Should().Be(1);
    }

    [Test]
    public void Calculate_WhenSourceAndTargetAreCompletelyDifferent_ShouldReturnStringLength()
    {
        // Arrange
        var input = new StringComparisonInput("abc", "def");

        // Act
        var distance = _calculator.Calculate(input);

        // Assert
        distance.Should().Be(3);
    }

    [Test]
    public void Calculate_WhenSourceAndTargetHaveDifferentCharactersAtMultiplePositions_ShouldReturnCorrectDistance()
    {
        // Arrange
        var input = new StringComparisonInput("abcde", "axcze");

        // Act
        var distance = _calculator.Calculate(input);

        // Assert
        distance.Should().Be(2);
    }

    [Test]
    public void Calculate_WhenSourceAndTargetHaveDifferentCases_ShouldCountAsDifferentCharacters()
    {
        // Arrange
        var input = new StringComparisonInput("Hello", "hELLO");

        // Act
        var distance = _calculator.Calculate(input);

        // Assert
        distance.Should().Be(5);
    }

    [Test]
    public void Calculate_WhenSourceAndTargetAreEmptyStrings_ShouldReturnZero()
    {
        // Arrange
        var input = new StringComparisonInput("", "");

        // Act
        var distance = _calculator.Calculate(input);

        // Assert
        distance.Should().Be(0);
    }

    [Test]
    public void Calculate_WhenSourceAndTargetHaveDifferentLengths_ShouldThrowArgumentException()
    {
        // Arrange
        var input = new StringComparisonInput("abc", "defg");

        // Act
        Action act = () => _calculator.Calculate(input);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("Strings should be of equal length - found A with length: 3 and B with length: 4");
    }
}