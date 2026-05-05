using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public abstract class PrioritySchedulerBase : IScheduler
{
    protected readonly IPriorityComparator _comparator;
    //protected readonly ProcessPriorityMode _mode;

    //public PrioritySchedulerBase(IPriorityComparator comparator,
    //                                ProcessPriorityMode mode)
    //{
    //    _comparator = comparator;
    //    _mode = mode;
    //}

    public PrioritySchedulerBase(IPriorityComparator comparator)
    {
        _comparator = comparator;
    }

    public abstract SchedulingTrace Schedule(List<Process> processes);

    protected Process GetHighestPriority(List<Process> readyQueue)
    {
        return readyQueue
            .OrderBy(p => p, new PriorityComparer(_comparator))
            .ThenBy(p => p.Data.ArrivalTime)
            .First();
    }
}
