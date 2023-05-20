using More.Trees.Models;

namespace More.Trees.Traversal;

public class DepthFirstTraverser<T>
{
    public IEnumerable<BinaryTreeNode<T>> Traverse(BinaryTreeNode<T>? node)
    {
        while (true)
        {
            if (node != null)
            {
                yield return node;

                foreach (var leftNode in Traverse(node.Left))
                {
                    yield return leftNode;
                }

                node = node.Right;
                continue;
            }

            break;
        }
    }

    public IEnumerable<TreeNode<T>> Traverse(TreeNode<T>? node)
    {
        if (node == null)
            yield break;

        yield return node;

        foreach (var descendant in node.Children.SelectMany(Traverse))
        {
            yield return descendant;
        }
    }
}