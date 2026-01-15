public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10 };
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        var l1c = 0;
        var l2c = 0;
        var count = 0;
        var size = select.Length;
        var result = new int[size];
        foreach (int number in select)
        {
            if (number == 1)
            {
                result[count] = list1[l1c++];
            }
            else if (number == 2)
            {
                result[count] = list2[l2c++];
            }

            ++count;
        }
        return result;
    }
}