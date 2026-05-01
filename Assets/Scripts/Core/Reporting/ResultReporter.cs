using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OS.Scheduling.Reporting
{
    public class ResultReporter
    {
        public Result Calculate(List<Process> processes)
        {
            double avgTAT = processes.Average(p => p.TurnaroundTime);
            double avgWT = processes.Average(p => p.WaitingTime);

            var rows = processes
                .OrderBy(p => p.Data.Pid)
                .Select(p => new ProcessRow(
                    p.Data.Pid,
                    p.Data.ArrivalTime,
                    p.Data.BurstTime,
                    p.Data.Priority,
                    p.CompletionTime,
                    p.TurnaroundTime,
                    p.WaitingTime
                ))
                .ToList();

            return new Result(
                rows: rows,
                avgTAT: avgTAT,
                avgWT: avgWT
            );
        }
    }

    public class ProcessRow
    {
        public int Pid { get; }
        public int ArrivalTime { get; }
        public int BurstTime { get; }
        public int Priority { get; }
        public int CompletionTime { get; }
        public int TurnaroundTime { get; }
        public int WaitingTime { get; }

        public ProcessRow(int pid, int arrivalTime, int burstTime, int priority, int completionTime, int turnaroundTime, int waitingTime)
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

    public class Result
    {
        public List<ProcessRow> Rows { get; }
        public double AvgTAT { get; }
        public double AvgWT { get; }

        public Result(List<ProcessRow> rows, double avgTAT, double avgWT)
        {
            Rows = rows;
            AvgTAT = avgTAT;
            AvgWT = avgWT;
        }
    }
}
