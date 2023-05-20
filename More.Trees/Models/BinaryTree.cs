namespace More.Trees.Models;

public class BinaryTree<T> where T : IComparable<T>
{
    public BinaryTreeNode<T>? Root { get; private set; }

    public BinaryTree()
    {
        Root = null;
    }

    public BinaryTree(BinaryTreeNode<T> root)
    {
        Root = root;
    }

    public void Add(T value)
    {
        var newNode = new BinaryTreeNode<T>(value);

        if (Root == null)
        {
            Root = newNode;
        }
        else
        {
            AddTo(Root, newNode);
        }
    }

    private void AddTo(BinaryTreeNode<T> node, BinaryTreeNode<T> newNode)
    {
        if (newNode.Value.CompareTo(node.Value) < 0)
        {
            if (node.Left == null)
            {
                node.Left = newNode;
            }
            else
            {
                AddTo(node.Left, newNode);
            }
        }
        else
        {
            if (node.Right == null)
            {
                node.Right = newNode;
            }
            else
            {
                AddTo(node.Right, newNode);
            }
        }
    }
}