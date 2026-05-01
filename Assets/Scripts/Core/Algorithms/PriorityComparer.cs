using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class PriorityComparer : IComparer<Process>
{
    private readonly IPriorityComparator _cmd;
    public PriorityComparer(IPriorityComparator cmd) => _cmd = cmd;
    public int Compare(Process p1, Process p2) => _cmd.Compare(p1, p2);
    //public int Compare(int pr1, int pr2) => _cmd.Compare(pr1, pr2);
}
