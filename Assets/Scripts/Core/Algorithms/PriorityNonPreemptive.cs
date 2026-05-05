using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class PriorityNonPreemptive : PrioritySchedulerBase
{
    public PriorityNonPreemptive(IPriorityComparator comparator) : base(comparator) {}

    // độ ưu tiên (số càng nhỏ thì càng ưu tiên hơn)
    public override SchedulingTrace Schedule(List<Process> processes)
    {
        var segments = new List<ExecutionSegment>();
        var readyQueue = new List<Process>();
        int time = 0, idx = 0;
        while (idx < processes.Count || readyQueue.Count > 0)
        {
            while (idx < processes.Count && processes[idx].Data.ArrivalTime <= time)
                readyQueue.Add(processes[idx++]);

            if (readyQueue.Count == 0)
            {
                time = processes[idx].Data.ArrivalTime;
                continue;
            }

            var highestPri = GetHighestPriority(readyQueue);
            readyQueue.Remove(highestPri);
            int start = time;
            time += highestPri.Data.BurstTime;
            highestPri.CompletionTime = time;
            segments.Add(new ExecutionSegment(highestPri.Data.Pid, start, time));
        }

        return new SchedulingTrace(processes, segments);
    }
}
