using System;

/// <summary>
/// This queue is circular. When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules). When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  
/// Each person stays in the queue and is given turns.  
/// - If turns > 0: they will be given that many turns.  
/// - If turns == 0 or < 0: they have infinite turns and never leave.  
/// If a person is out of turns, they will not be added back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left.  
    /// A turns value of 0 or less means the person has an infinite number of turns.  
    /// An exception is thrown if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue."); // FIX: match test exactly
        }

        Person person = _people.Dequeue();

        if (person.Turns > 1)
        {
            // Finite turns left: give one turn, decrement, re-add
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        else if (person.Turns == 1)
        {
            // This was their last turn → do not re-add
        }
        else
        {
            // Infinite turns: 0 or less means forever → put back with no changes
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
