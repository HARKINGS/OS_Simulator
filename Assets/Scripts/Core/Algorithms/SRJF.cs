using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
public class SRJF : IScheduler
{
    public void Schedule(List<Process> processes)
    {
        var sortedProcesses = processes;
        var readyQueue = new List<Process>();
        int time = 0, idx = 0;

        while (idx < sortedProcesses.Count || readyQueue.Count > 0)
        {
            // 1. Nạp tất cả tiến trình đã đến vào hàng đợi
            while (idx < sortedProcesses.Count && sortedProcesses[idx].Data.ArrivalTime <= time)
                readyQueue.Add(sortedProcesses[idx++]);
            if (readyQueue.Count == 0)
            {
                // CPU rảnh, nhảy đến thời điểm tiến trình tiếp theo đến
                time = sortedProcesses[idx].Data.ArrivalTime;
                continue;
            }

            // 2. SRJF: Luôn chọn tiến trình có Remaining Time thấp nhất
            var current = readyQueue.OrderBy(p => p.RemainingTime)
                                    .ThenBy(p => p.Data.ArrivalTime) // Nếu bằng nhau thì chọn tiến trình đến trước
                                    .First();

            // 3. Xác định thời gian thực thi tối đa cho đến "sự kiện" tiếp theo
            int timeToNextArrival = (idx < sortedProcesses.Count)
                ? sortedProcesses[idx].Data.ArrivalTime - time
                : int.MaxValue;

            int timeToFinish = current.RemainingTime;
            int execTime = Math.Min(timeToNextArrival, timeToFinish);

            // 4. Cập nhật trạng thái
            time += execTime;
            current.RemainingTime -= execTime;

            if (current.RemainingTime == 0)
            {
                current.CompletionTime = time;
                readyQueue.Remove(current);
            }
        }
    }
}
