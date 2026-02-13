using System.Threading.Channels;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
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
        // TODO Start Problem 2
        bool result = false;
        if (Data == value)
        {
            result = true;
        }
        else if (Data > value && Left != null)
        {
            result = Left.Contains(value);
        }
        else if (Data < value && Right != null)
        {
            result = Right.Contains(value);
        }
        return result;
    }

    public int GetHeight()
    {
        int height = 1;
        int heightLeft = 0;
        int heightRight = 0;
        if (Left != null)
        {
            heightLeft = Left.GetHeight();
        }
        if (Right != null)
        {
            heightRight = Right.GetHeight();
        }

        if (heightLeft >= heightRight)
        {
            height += heightLeft;
        }
        else
        {
            height += heightRight;
        }
        // TODO Start Problem 4
        return height; // Replace this line with the correct return statement(s)
    }
}