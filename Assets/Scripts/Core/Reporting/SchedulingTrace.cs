using System.Collections.Generic;
using UnityEngine;

public class SchedulingTrace
{ 
    public List<Process> Processes { get; private set; }
    public List<ExecutionSegment> Segments { get; private set; }

    public SchedulingTrace(List<Process> processes, List<ExecutionSegment> segments)
    {
        Processes = processes;
        Segments = segments;
    }
}
