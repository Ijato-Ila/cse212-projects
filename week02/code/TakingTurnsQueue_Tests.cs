using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod]
    // Scenario: Add two people with finite turns and let them alternate until turns run out
    // Expected Result: Bob finishes first, Sue gets last turn
    // Defect(s) Found: Bug fixed in GetNextPerson (wrong order previously returned)
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Bob", 2);
        queue.AddPerson("Sue", 2);

        Assert.AreEqual("Bob", queue.GetNextPerson().Name);
        Assert.AreEqual("Sue", queue.GetNextPerson().Name);
        Assert.AreEqual("Bob", queue.GetNextPerson().Name);  // Bob’s last turn
        Assert.AreEqual("Sue", queue.GetNextPerson().Name);  // Sue’s last turn
    }

    [TestMethod]
    // Scenario: Add a new person in the middle of rotation
    // Expected Result: Bob goes, Sue goes, then Tim joins at the back
    // Defect(s) Found: Bug in PersonQueue (wrong insertion order) fixed
    public void TestTakingTurnsQueue_AddPlayerMidway()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Bob", 2);
        queue.AddPerson("Sue", 2);

        Assert.AreEqual("Bob", queue.GetNextPerson().Name);
        Assert.AreEqual("Sue", queue.GetNextPerson().Name);

        queue.AddPerson("Tim", 2);

        Assert.AreEqual("Bob", queue.GetNextPerson().Name);
        Assert.AreEqual("Sue", queue.GetNextPerson().Name);
        Assert.AreEqual("Tim", queue.GetNextPerson().Name);
    }

    [TestMethod]
    // Scenario: Person with turns = 0 (infinite turns)
    // Expected Result: Bob always comes back regardless of Sue running out
    // Defect(s) Found: Fixed handling of infinite turns (0 or less)
    public void TestTakingTurnsQueue_ForeverZero()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Bob", 0);  // infinite turns
        queue.AddPerson("Sue", 2);

        Assert.AreEqual("Bob", queue.GetNextPerson().Name);
        Assert.AreEqual("Sue", queue.GetNextPerson().Name);
        Assert.AreEqual("Bob", queue.GetNextPerson().Name);
        Assert.AreEqual("Sue", queue.GetNextPerson().Name);
        Assert.AreEqual("Bob", queue.GetNextPerson().Name); // Sue is out, only Bob remains
    }

    [TestMethod]
    // Scenario: Person with turns = negative number (infinite turns)
    // Expected Result: Tim always comes back regardless of Sue running out
    // Defect(s) Found: Same infinite turns bug fixed
    public void TestTakingTurnsQueue_ForeverNegative()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Tim", -5); // infinite turns
        queue.AddPerson("Sue", 2);

        Assert.AreEqual("Tim", queue.GetNextPerson().Name);
        Assert.AreEqual("Sue", queue.GetNextPerson().Name);
        Assert.AreEqual("Tim", queue.GetNextPerson().Name);
        Assert.AreEqual("Sue", queue.GetNextPerson().Name);
        Assert.AreEqual("Tim", queue.GetNextPerson().Name); // Sue is out
    }

    [TestMethod]
    // Scenario: Try to get next person from an empty queue
    // Expected Result: Should throw InvalidOperationException with "No one in the queue."
    // Defect(s) Found: Error message didn’t match, fixed to match requirements
    public void TestTakingTurnsQueue_Empty()
    {
        var queue = new TakingTurnsQueue();
        try
        {
            queue.GetNextPerson();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("No one in the queue.", ex.Message);
        }
    }
}
