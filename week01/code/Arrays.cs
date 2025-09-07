using System;
using System.Collections.Generic;
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

        // My Plan:
        // 1. I Create an array called "result" with length equal to 'length'.
        // 2. I use a for-loop that goes from i = 0 to i = length - 1.
        // 3. Then for each index i, I calculate number * (i+1) to get the multiple.
        // 4. Store the multiple inside result[i].
        // 5. After the loop finishes, return the array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
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

        // My Plan:
        // 1. I Get the total number of items in the list (n).
        // 2. If the list is empty, return right away.
        // 3. Find k = amount % n (so it works even if amount == n).
        // 4. If k == 0, nothing changes, so return.
        // 5. Then take the last k elements and the first n-k elements using GetRange.
        // 6. Clear the original list.
        // 7. Add the last k elements first, then add the first n-k elements.

        int n = data.Count;
        if (n == 0) return;

        int k = amount % n;
        if (k == 0) return;

        List<int> right = data.GetRange(n - k, k);
        List<int> left = data.GetRange(0, n - k);

        data.Clear();
        data.AddRange(right);
        data.AddRange(left);
    }
}
