using UnityEngine;

public class HighNumberHighPriority : IPriorityComparator
{
    public int Compare(Process p1, Process p2) => p2.Data.Priority.CompareTo(p1.Data.Priority);
    //public int Compare(int p1, int p2) => p2.CompareTo(p1);
}
