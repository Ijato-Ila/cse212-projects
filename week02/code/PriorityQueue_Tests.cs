using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue a single item and then dequeue it
    // Expected Result: The same item should be returned
    // Defect(s) Found: None
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Alice", 1);
        Assert.AreEqual("Alice", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue two items with different priorities (higher priority second)
    // Expected Result: The higher priority item should be dequeued first
    // Defect(s) Found: None
    public void TestPriorityQueue_HigherPriorityFirst()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Alice", 1);
        priorityQueue.Enqueue("Bob", 5);
        Assert.AreEqual("Bob", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue two items with the same priority
    // Expected Result: The first enqueued item should be dequeued first (FIFO order)
    // Defect(s) Found: None
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Alice", 3);
        priorityQueue.Enqueue("Bob", 3);
        Assert.AreEqual("Alice", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: Should throw an InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Original bug in PriorityQueue.cs where queue removal wasn’t implemented
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with mixed priorities
    // Expected Result: Items should be dequeued in order of priority, breaking ties with FIFO
    // Defect(s) Found: None
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Alice", 2);
        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Charlie", 5);
        priorityQueue.Enqueue("Dave", 1);

        Assert.AreEqual("Bob", priorityQueue.Dequeue());     // Highest priority
        Assert.AreEqual("Charlie", priorityQueue.Dequeue()); // Same priority, FIFO
        Assert.AreEqual("Alice", priorityQueue.Dequeue());   // Next priority
    }
}
