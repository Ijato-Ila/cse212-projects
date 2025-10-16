public class Node
{
    public int Data { get; set; }
    public Node? Left { get; private set; }
    public Node? Right { get; private set; }

    public Node(int data)
    {
        Data = data;
    }

    public void Insert(int value)
    {
        // TODO Problem 1
        // If the value already exists, do nothing (no duplicates allowed)
        if (value == Data)
            return;

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Problem 2
        if (value == Data)
            return true;

        if (value < Data && Left != null)
            return Left.Contains(value);

        if (value > Data && Right != null)
            return Right.Contains(value);

        return false;
    }

    public int GetHeight()
    {
        // TODO Problem 4
        // Base case: empty node contributes height 0
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        // Height = 1 (this node) + taller subtree
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
