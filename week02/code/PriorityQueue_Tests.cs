using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Basic priority removal
    // Expected Result: "B"
    // Defect(s) Found: Highest priority not correctly selected
    public void TestPriorityQueue_HighestPriorityRemoved()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        var result = pq.Dequeue();

        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: FIFO when priorities are equal
    // Expected Result: "A"
    // Defect(s) Found: Tie-breaking not FIFO
    public void TestPriorityQueue_FIFO_TieBreaker()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 1);

        var result = pq.Dequeue();

        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Multiple dequeues maintain correct behavior
    // Expected Result: A, B, C order by priority
    // Defect(s) Found: Item not removed after dequeue
    public void TestPriorityQueue_MultipleDequeues()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 10);
        pq.Enqueue("C", 5);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Empty queue throws exception
    // Expected Result: InvalidOperationException with correct message
    // Defect(s) Found: Missing exception or wrong message
    public void TestPriorityQueue_EmptyQueue()
    {
        var pq = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() =>
        {
            pq.Dequeue();
        });

        Assert.AreEqual("The queue is empty.", ex.Message);
    }
}