using UnityEngine;

public class HighNumberHighPriority : IPriorityComparator
{
    public int Compare(Process p1, Process p2) => p2.Data.Priority.CompareTo(p1.Data.Priority);
}
