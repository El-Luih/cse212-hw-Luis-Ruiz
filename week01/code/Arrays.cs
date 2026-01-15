public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        /*
        1. Create an empty fixed-size double array named results using length as its size. 
            This array will store the multiples of the given number.
        2. Use a for loop to multiply number by coefficients ranging from 1 to length. 
            The loop should start with i = 0, continue while i < length, and increase i by 1 on each iteration.
        3. Inside the loop, create a variable p (for product) that stores the result of
            number * (i + 1), since the index starts at 0.
        4. Still inside the loop, assign the value of p to the correct index of the results array using i.
        5. After the loop finishes, return the results array.
        */

        var results = new double[length];

        for (int i = 0; i < length; i++)
        {
            double p = number * (i + 1);
            results[i] = p;
        }


        return results; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        /*
        1. Create a new List<int> element called "displaced" from a range of items of "data". This range starts at index 0 
            and retrieves a number of items equal to the total amount of items minus the specified "amount" argument.
        2. Remove the same range of items from the "data" list after retrieving their values.
        3. Append the "displaced" array to the end of the modified "data" list.
        */
        List<int> displaced = data.GetRange(0, data.Count - amount);
        data.RemoveRange(0, data.Count - amount);
        data.AddRange(displaced);
    }
}
