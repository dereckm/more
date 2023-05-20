using System;
using More.Trees.Conversion;

using FluentAssertions;
using NUnit.Framework;

namespace More.Trees.Tests.Conversion;

[TestFixture]
public class ArrayToBinaryTreeConverterTests
{
    [Test]
    public void ConvertToBinaryTree_WithNullArray_ReturnsEmptyBinaryTree()
    {
        // Arrange
        int[]? array = null;
        var converter = new ArrayToBinaryTreeConverter<int>();

        // Act
        var result = converter.ConvertToBinaryTree(array);

        // Assert
        result.Should().NotBeNull();
        result.Root.Should().BeNull();
    }

    [Test]
    public void ConvertToBinaryTree_WithEmptyArray_ReturnsEmptyBinaryTree()
    {
        // Arrange
        var array = Array.Empty<int>();
        var converter = new ArrayToBinaryTreeConverter<int>();

        // Act
        var result = converter.ConvertToBinaryTree(array);

        // Assert
        result.Should().NotBeNull();
        result.Root.Should().BeNull();
    }

    [Test]
    public void ConvertToBinaryTree_WithNonEmptyArray_ReturnsCorrectBinaryTree()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5, 6, 7 };
        var converter = new ArrayToBinaryTreeConverter<int>();

        // Act
        var result = converter.ConvertToBinaryTree(array);

        // Assert
        result.Should().NotBeNull();
        result.Root.Should().NotBeNull();
        result.Root.Value.Should().Be(array[0]);
        result.Root.Left.Value.Should().Be(array[1]);
        result.Root.Right.Value.Should().Be(array[2]);
        result.Root.Left.Left.Value.Should().Be(array[3]);
        result.Root.Left.Right.Value.Should().Be(array[4]);
        result.Root.Right.Left.Value.Should().Be(array[5]);
        result.Root.Right.Right.Value.Should().Be(array[6]);
    }
}
