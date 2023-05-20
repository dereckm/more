using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using More.Trees.Models;
using More.Trees.Traversal;
using NUnit.Framework;

namespace More.Trees.Tests.Traversal
{
    [TestFixture]
    public class BreadthFirstTraverserTests
    {
        private class TestData
        {
            public int Value { get; set; }
        }

        [Test]
        public void Traverse_BinaryTree_WhenSingleNode_ShouldReturnSingleNode()
        {
            // Arrange
            var root = new BinaryTreeNode<TestData>(new TestData { Value = 1 });
            var traverser = new BreadthFirstTraverser<TestData>();

            // Act
            var result = traverser.Traverse(root);

            // Assert
            result.First().Should().BeEquivalentTo(root);
        }

        [Test]
        public void Traverse_BinaryTree_WhenMultipleNodes_ShouldReturnNodesInBfsOrder()
        {
            // Arrange
            var root = new BinaryTreeNode<TestData>(new TestData { Value = 1 });
            var node2 = new BinaryTreeNode<TestData>(new TestData { Value = 2 });
            var node3 = new BinaryTreeNode<TestData>(new TestData { Value = 3 });
            var node4 = new BinaryTreeNode<TestData>(new TestData { Value = 4 });
            var node5 = new BinaryTreeNode<TestData>(new TestData { Value = 5 });

            root.Left = node2;
            root.Right = node3;
            node3.Left = node4;
            node3.Right = node5;

            var traverser = new BreadthFirstTraverser<TestData>();

            // Act
            var result = traverser.Traverse(root);

            // Assert
            var expected = new List<BinaryTreeNode<TestData>>
            {
                root,
                node2,
                node3,
                node4,
                node5
            };
            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Traverse_BinaryTree_WhenEmptyTree_ShouldReturnEmptyResult()
        {
            // Arrange
            BinaryTreeNode<TestData>? root = null;
            var traverser = new BreadthFirstTraverser<TestData>();

            // Act
            var result = traverser.Traverse(root);

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public void Traverse_GeneralTree_WhenSingleNode_ShouldReturnSingleNode()
        {
            // Arrange
            var root = new TreeNode<TestData>(new TestData { Value = 1 });
            var traverser = new BreadthFirstTraverser<TestData>();

            // Act
            var result = traverser.Traverse(root);

            // Assert
            result.First().Should().BeEquivalentTo(root);
        }

        [Test]
        public void Traverse_GeneralTree_WhenMultipleNodes_ShouldReturnNodesInBfsOrder()
        {
            // Arrange
            var root = new TreeNode<TestData>(new TestData { Value = 1 });
            var item2 = new TestData { Value = 2 };
            var item3 = new TestData { Value = 3 };
            var item4 = new TestData { Value = 4 };
            var item5 = new TestData { Value = 5 };
            var item6 = new TestData { Value = 6 };

            var node2 = root.AddChild(item2);
            var node3 = root.AddChild(item3);
            var node4 = node3.AddChild(item4);
            var node5 = node3.AddChild(item5);
            var node6 = node2.AddChild(item6);

            var traverser = new BreadthFirstTraverser<TestData>();

            // Act
            var result = traverser.Traverse(root);

            // Assert
            var expected = new List<TreeNode<TestData>>
            {
                root,
                node2,
                node3,
                node6,
                node4,
                node5
            };
            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Traverse_GeneralTree_WhenEmptyTree_ShouldReturnEmptyResult()
        {
            // Arrange
            TreeNode<TestData>? root = null;
            var traverser = new BreadthFirstTraverser<TestData>();

            // Act
            var result = traverser.Traverse(root);

            // Assert
            result.Should().BeEmpty();
        }
    }
}
