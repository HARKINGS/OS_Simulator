using UnityEngine;
using System.Collections.Generic;
using System;

public class FCFS : IScheduler
{
    public void Schedule(List<Process> processes)
    {
        int time = 0;
        foreach (var p in processes)
        {
            time = Math.Max(time, p.Data.ArrivalTime);
            p.CompletionTime = time + p.Data.BurstTime;
            time = p.CompletionTime;
        }
    }
}
