using UnityEngine;
using System.Collections.Generic;
using System;

public class FCFS : IScheduler
{
    public SchedulingTrace Schedule(List<Process> processes)
    {
        var segments = new List<ExecutionSegment>();
        int time = 0;

        foreach (var p in processes)
        {
            int start = Math.Max(time, p.Data.ArrivalTime);
            int end = start + p.Data.BurstTime;

            p.CompletionTime = end;
            segments.Add(new ExecutionSegment(p.Data.Pid, start, end));

            time = end;
        }

        return new SchedulingTrace(processes, segments);
    }
}
