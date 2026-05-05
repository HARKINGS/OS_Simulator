using System;
using System.Collections.Generic;
using System.Linq;

public class SJF : IScheduler
{
    public SchedulingTrace Schedule(List<Process> processes)
    {
        List<ExecutionSegment> segments = new List<ExecutionSegment>();
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

            var shortest = readyQueue.OrderBy(p => p.Data.BurstTime).First();
            readyQueue.Remove(shortest);

            int start = time;
            time += shortest.Data.BurstTime;
            shortest.CompletionTime = time;

            segments.Add(new ExecutionSegment(shortest.Data.Pid, start, time));
        }

        return new SchedulingTrace(processes, segments);
    }
}

