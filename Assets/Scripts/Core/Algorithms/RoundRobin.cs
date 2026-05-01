using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class RoundRobin : IScheduler
{
    private readonly int quantumTime;

    public RoundRobin(int quantumTime) => this.quantumTime = quantumTime;

    public void Schedule(List<Process> processes)
    {
        var queue = new Queue<Process>();
        int time = 0, idx = 0;
        while (idx < processes.Count || queue.Count > 0)
        {
            if (queue.Count == 0)
            {
                time = processes[idx].Data.ArrivalTime;
                queue.Enqueue(processes[idx++]);
                continue;
            }

            var p = queue.Dequeue(); // Lấy ra từ đầu

            int exec = Math.Min(quantumTime, p.RemainingTime);
            time += exec;
            p.RemainingTime -= exec;

            while (idx < processes.Count &&
                processes[idx].Data.ArrivalTime <= time)
                queue.Enqueue(processes[idx++]); // Thêm vào cuối

            if (p.RemainingTime > 0) queue.Enqueue(p);
            else p.CompletionTime = time;
        }
    }
}

