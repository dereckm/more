using More.Trees.Models;

namespace More.Trees.Traversal;

public class BreadthFirstTraverser<T>
{
    public IEnumerable<BinaryTreeNode<T>> Traverse(BinaryTreeNode<T>? root)
    {
        if (root == null)
            yield break;

        var queue = new Queue<BinaryTreeNode<T>>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            yield return node;

            if (node.Left != null)
                queue.Enqueue(node.Left);

            if (node.Right != null)
                queue.Enqueue(node.Right);
        }
    }
    
    public IEnumerable<TreeNode<T>> Traverse(TreeNode<T>? node)
    {
        if (node == null)
            yield break;

        var queue = new Queue<TreeNode<T>>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();
            yield return currentNode;

            foreach (var child in currentNode.Children)
                queue.Enqueue(child);
        }
    }
}