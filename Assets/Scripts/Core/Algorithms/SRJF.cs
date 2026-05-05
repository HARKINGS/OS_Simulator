using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
public class SRJF : IScheduler
{
    public SchedulingTrace Schedule(List<Process> processes)
    {
        var segments = new List<ExecutionSegment>();
        var readyQueue = new List<Process>();
        int time = 0, idx = 0;

        while (idx < processes.Count || readyQueue.Count > 0)
        {
            // 1. Nạp tất cả tiến trình đã đến vào hàng đợi
            while (idx < processes.Count && processes[idx].Data.ArrivalTime <= time)
                readyQueue.Add(processes[idx++]);
            if (readyQueue.Count == 0)
            {
                // CPU rảnh, nhảy đến thời điểm tiến trình tiếp theo đến
                time = processes[idx].Data.ArrivalTime;
                continue;
            }

            // 2. SRJF: Luôn chọn tiến trình có Remaining Time thấp nhất
            var current = readyQueue.OrderBy(p => p.RemainingTime)
                                    .ThenBy(p => p.Data.ArrivalTime) // Nếu bằng nhau thì chọn tiến trình đến trước
                                    .First();

            // 3. Xác định thời gian thực thi tối đa cho đến "sự kiện" tiếp theo
            int timeToNextArrival = (idx < processes.Count)
                ? processes[idx].Data.ArrivalTime - time
                : int.MaxValue;

            int timeToFinish = current.RemainingTime;
            int execTime = Math.Min(timeToNextArrival, timeToFinish);
            int start = time;

            // 4. Cập nhật trạng thái
            time += execTime;
            current.RemainingTime -= execTime;
            segments.Add(new ExecutionSegment(current.Data.Pid, start, time));

            if (current.RemainingTime == 0)
            {
                current.CompletionTime = time;
                readyQueue.Remove(current);
            }   
        }

        return new SchedulingTrace(processes, segments);
    }
}
