public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST to start with 
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// This function inserts the middle value of a sorted array range into the BST.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // TODO Start Problem 5

        // Base case: if our range is invalid, stop recursion
        if (first > last)
            return;

        // Find the middle index between first and last
        int middle = (first + last) / 2;

        // Insert the middle element into the BST
        bst.Insert(sortedNumbers[middle]);

        // Recursively insert values from the left half
        InsertMiddle(sortedNumbers, first, middle - 1, bst);

        // Recursively insert values from the right half
        InsertMiddle(sortedNumbers, middle + 1, last, bst);
    }
}
