using UnityEngine;

public interface IPriorityComparator
{
    int Compare(Process p1, Process p2);
    //int Compare(int pr1, int pr2);
}
