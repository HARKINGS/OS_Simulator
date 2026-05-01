using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class Process
{
    public ProcessDto Data { get; }
    public int RemainingTime { get; set; } // Thời gian còn lại, sử dụng trong thuật toán Round Robin
    public int CompletionTime { get; set; }

    public int WaitingTime => CompletionTime - Data.ArrivalTime - Data.BurstTime;
    public int TurnaroundTime => CompletionTime - Data.ArrivalTime;

    public Process(ProcessDto dto)
    {
        Data = dto;
        RemainingTime = dto.BurstTime;
    }
}
