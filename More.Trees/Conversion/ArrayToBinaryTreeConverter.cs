using More.Trees.Models;

namespace More.Trees.Conversion;

public class ArrayToBinaryTreeConverter<T> where T : IComparable<T>
{
    public BinaryTree<T> ConvertToBinaryTree(T[]? array)
    {
        if (array == null || array.Length == 0)
            return new BinaryTree<T>();

        var root = CreateBinaryTree(array, 0);
        return new BinaryTree<T>(root);
    }

    private static BinaryTreeNode<T> CreateBinaryTree(IReadOnlyList<T>? array, int index)
    {
        if (index >= array.Count)
            return null;

        var node = new BinaryTreeNode<T>(array[index])
        {
            Left = CreateBinaryTree(array, 2 * index + 1),
            Right = CreateBinaryTree(array, 2 * index + 2)
        };

        return node;
    }
}
