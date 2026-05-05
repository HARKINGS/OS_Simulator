using OS.Scheduling.Reporting;
using System.Collections.Generic;
using UnityEngine;

public class SchedulingResult
{
    public List<ProcessResultRow> Rows { get; }
    public List<ExecutionSegment> Segments { get; }
    public double AvgTAT { get; }
    public double AvgWT { get; }

    public SchedulingResult(
        List<ProcessResultRow> rows, 
        List<ExecutionSegment> segments,
        double avgTAT, 
        double avgWT)
    {
        Rows = rows;
        Segments = segments;
        AvgTAT = avgTAT;
        AvgWT = avgWT;
    }
}
