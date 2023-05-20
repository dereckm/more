namespace More.Trees.Models;

public class Tree<T>
{
    public TreeNode<T> Root { get; }

    public Tree(T rootValue)
    {
        Root = new TreeNode<T>(rootValue);
    }
}