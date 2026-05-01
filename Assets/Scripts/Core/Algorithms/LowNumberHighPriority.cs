using UnityEngine;

public class LowNumberHighPriority : IPriorityComparator
{
    public int Compare(Process p1, Process p2) => p1.Data.Priority.CompareTo(p2.Data.Priority);
    //public int Compare(int pr1, int pr2) => pr1.CompareTo(pr2);
}
