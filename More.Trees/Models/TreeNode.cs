namespace More.Trees.Models;

public class TreeNode<T>
{
    public T Value { get; }
    public List<TreeNode<T>> Children { get; }

    public TreeNode(T value)
    {
        Value = value;
        Children = new List<TreeNode<T>>();
    }

    public TreeNode<T> AddChild(T childValue)
    {
        var childNode = new TreeNode<T>(childValue);
        Children.Add(childNode);
        return childNode;
    }
}