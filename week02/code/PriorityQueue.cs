using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  
    /// The item is always added to the back of the queue.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Remove and return the value with the highest priority.
    /// If multiple items share the same highest priority, 
    /// the one closest to the front is removed first (FIFO).
    /// If the queue is empty, throw an exception.
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority
        int highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++) // FIX: include last item
        {
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority) // FIX: only strictly greater
            {
                highPriorityIndex = index;
            }
        }

        // Remove and return the item with the highest priority
        string value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex); // FIX: actually remove it
        return value;
    }

    // DO NOT MODIFY
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
