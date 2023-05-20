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

    private static void AddTo(BinaryTreeNode<T> node, BinaryTreeNode<T> newNode)
    {
        while (true)
        {
            if (newNode.Value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = newNode;
                }
                else
                {
                    node = node.Left;
                    continue;
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
                    node = node.Right;
                    continue;
                }
            }

            break;
        }
    }
}