using System;
using System.Collections.Generic;
using System.Linq;

namespace OS.Scheduling.Reporting
{
    public class ResultReporter
    {
        public SchedulingResult Calculate(SchedulingTrace trace)
        {
            var processes = trace.Processes;

            double avgTAT = Math.Round(processes.Average(p => p.TurnaroundTime), 2);
            double avgWT = Math.Round(processes.Average(p => p.WaitingTime), 2);

            var rows = processes
                .OrderBy(p => p.Data.Pid)
                .Select(p => new ProcessResultRow(
                    p.Data.Pid,
                    p.Data.ArrivalTime,
                    p.Data.BurstTime,
                    p.Data.Priority,
                    p.CompletionTime,
                    p.TurnaroundTime,
                    p.WaitingTime
                ))
                .ToList();

            return new SchedulingResult(
                rows: rows,
                segments: trace.Segments,
                avgTAT: avgTAT,
                avgWT: avgWT
            );
        }
    }

    public class ProcessResultRow
    {
        public int Pid { get; }
        public int ArrivalTime { get; }
        public int BurstTime { get; }
        public int Priority { get; }
        public int CompletionTime { get; }
        public int TurnaroundTime { get; }
        public int WaitingTime { get; }

        public ProcessResultRow(int pid, int arrivalTime, int burstTime, int priority, int completionTime, int turnaroundTime, int waitingTime)
        {
            Pid = pid;
            ArrivalTime = arrivalTime;
            BurstTime = burstTime;
            Priority = priority;
            CompletionTime = completionTime;
            TurnaroundTime = turnaroundTime;
            WaitingTime = waitingTime;
        }
    }
}
