using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: A series of values related to an specific numeric poisition are enqueued in a disordely manner while being assigned to a priority 
    // corresponding to said numeric position according to the intended behavior of the priority queue. None of the values share the same priority number.
    // Expected Result: sub1, sub2, sub3, sub4, sub5
    // Defect(s) Found: 
    // - Assert.AreEqual failed. Expected:<Subject 2>. Actual:<Subject 1>: Subject 1 was not deleted when picked as the highest priority value.
    // - Assert.AreEqual failed. Expected:<Subject 3>. Actual:<Subject 4>: The Dequeue() method uses "_queue.Count - 1" as the count limit, so the last value is not checked.
    public void TestPriorityQueue_PrioritySorting()
    {
        var pQ = new PriorityQueue();

        var sub5 = "Subject 5";
        var sub4 = "Subject 4";
        var sub3 = "Subject 3";
        var sub2 = "Subject 2";
        var sub1 = "Subject 1";

        var guideline = new[] { sub1, sub2, sub3, sub4, sub5 };
        var results = new string[5];

        pQ.Enqueue(sub4, 2);
        pQ.Enqueue(sub5, 1);
        pQ.Enqueue(sub1, 5);
        pQ.Enqueue(sub2, 4);
        pQ.Enqueue(sub3, 3);

        for (int i = 0; i < 5; i++)
        {
            results[i] = pQ.Dequeue();
            Assert.AreEqual(guideline[i], results[i]);
        }

    }

    [TestMethod]
    // Scenario: A set of values are enqueued. Some values share the same priority number. The correct positions of the values are included in their names.
    // Expected Result: sub1, sub2, sub3, sub4, sub5, sub6
    // Defect(s) Found: 
    // - Assert.AreEqual failed. Expected:<Subject 2>. Actual:<Subject 1>: Subject 1 was not deleted when picked as the highest priority value. 
    // - Assert.AreEqual failed. Expected:<Subject 1>. Actual:<Subject 2>: The Dequeue() method uses a "<=" operator. This can cause an item in a posterior position 
    // but with the same priority number as the last high priority item to override it.
    public void TestPriorityQueue_PositionSorting()
    {
        var pQ = new PriorityQueue();

        var sub6 = "Subject 6";
        var sub5 = "Subject 5";
        var sub4 = "Subject 4";
        var sub3 = "Subject 3";
        var sub2 = "Subject 2";
        var sub1 = "Subject 1";

        var guideline = new[] { sub1, sub2, sub3, sub4, sub5, sub6 };
        var results = new string[6];

        pQ.Enqueue(sub1, 3);
        pQ.Enqueue(sub3, 2);
        pQ.Enqueue(sub5, 1);
        pQ.Enqueue(sub2, 3);
        pQ.Enqueue(sub4, 2);
        pQ.Enqueue(sub6, 1);

        for (int i = 0; i < 6; i++)
        {
            results[i] = pQ.Dequeue();
            Assert.AreEqual(guideline[i], results[i]);
        }
    }
    // Add more test cases as needed below.


    [TestMethod]
    // Scenario: A new empty PriorityQueue is created. Immediately after, an attempt to dequeue is made.
    // Expected Result: An InvalidOperationException error shoould be catched. The error message must match the specified message set for this case.
    // Defect(s) Found: 
    public void TestPriorityQueue_Empty()
    {
        var pQ = new PriorityQueue();

        try
        {
            pQ.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}