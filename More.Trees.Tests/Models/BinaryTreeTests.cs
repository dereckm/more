using FluentAssertions;
using More.Trees.Models;
using NUnit.Framework;

namespace More.Trees.Tests.Models;

[TestFixture]
public class BinaryTreeTests
{
    [Test]
    public void Add_WhenTreeIsEmpty_AddsRootNode()
    {
        // Arrange
        var tree = new BinaryTree<int>();

        // Act
        tree.Add(5);

        // Assert
        tree.Root.Should().NotBeNull();
        tree.Root.Value.Should().Be(5);
        tree.Root.Left.Should().BeNull();
        tree.Root.Right.Should().BeNull();
    }

    [Test]
    public void Add_WhenAddingSmallerValue_AddsNodeToTheLeft()
    {
        // Arrange
        var tree = new BinaryTree<int>();
        tree.Add(5);

        // Act
        tree.Add(3);

        // Assert
        tree.Root.Should().NotBeNull();
        tree.Root.Value.Should().Be(5);
        tree.Root.Left.Should().NotBeNull();
        tree.Root.Left.Value.Should().Be(3);
        tree.Root.Right.Should().BeNull();
    }

    [Test]
    public void Add_WhenAddingLargerValue_AddsNodeToTheRight()
    {
        // Arrange
        var tree = new BinaryTree<int>();
        tree.Add(5);

        // Act
        tree.Add(8);

        // Assert
        tree.Root.Should().NotBeNull();
        tree.Root.Value.Should().Be(5);
        tree.Root.Left.Should().BeNull();
        tree.Root.Right.Should().NotBeNull();
        tree.Root.Right.Value.Should().Be(8);
    }

    [Test]
    public void Add_WhenAddingEqualValue_DoesNotAddNode()
    {
        // Arrange
        var tree = new BinaryTree<int>();

        // Act
        tree.Add(5);

        // Assert
        tree.Root.Should().NotBeNull();
        tree.Root.Value.Should().Be(5);
        tree.Root.Left.Should().BeNull();
        tree.Root.Right.Should().BeNull();
    }
}