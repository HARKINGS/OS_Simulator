using UnityEngine;

public class ExecutionSegment
{
    public int Pid { get; }
    public int StartTime { get; }
    public int EndTime { get; }

    public ExecutionSegment(int pid, int startTime, int endTime)
    {
        Pid = pid;
        StartTime = startTime;
        EndTime = endTime;
    }

    public int Duration => EndTime - StartTime;
}