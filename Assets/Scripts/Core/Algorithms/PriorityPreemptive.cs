using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class PriorityPreemptive : PrioritySchedulerBase
{
    public PriorityPreemptive(IPriorityComparator comparator) : base(comparator) {}

    public override SchedulingTrace Schedule(List<Process> processes)
    {
        var segments = new List<ExecutionSegment>();
        var readyQueue = new List<Process>();
        int time = 0, idx = 0;
        Process currentProcess = null;

        while (idx < processes.Count || readyQueue.Count > 0 || currentProcess != null)
        {
            // 1. Thêm tất cả tiến trình mới đến vào Ready Queue
            while (idx < processes.Count && processes[idx].Data.ArrivalTime <= time)
                readyQueue.Add(processes[idx++]);

            // 2. Nếu đang có tiến trình chạy, bỏ nó lại vào Queue để so sánh ưu tiên mới
            if (currentProcess != null)
            {
                readyQueue.Add(currentProcess);
                currentProcess = null;
            }

            if (readyQueue.Count == 0)
            {
                if (idx < processes.Count)
                    time = processes[idx].Data.ArrivalTime; // Nhảy thời gian nếu CPU rảnh
                continue;
            }

            // 3. Chọn tiến trình ưu tiên nhất từ Queue
            currentProcess = GetHighestPriority(readyQueue);
            readyQueue.Remove(currentProcess);

            // 4. Tính toán thời gian thực thi tối đa đến "sự kiện" tiếp theo
            // Sự kiện tiếp theo là: Hoặc tiến trình xong, hoặc có tiến trình mới đến
            int timeToNextArrival = (idx < processes.Count)
                ? processes[idx].Data.ArrivalTime - time
                : int.MaxValue;

            int timeToFinish = currentProcess.RemainingTime;
            int execTime = Math.Min(timeToNextArrival, timeToFinish);

            // 5. Thực thi
            if (execTime <= 0) execTime = 1; // Đảm bảo luôn tiến về phía trước nếu timeToNextArrival = 0

            int start = time;
            currentProcess.RemainingTime -= execTime;
            time += execTime;

            segments.Add(new ExecutionSegment(currentProcess.Data.Pid, start, time));

            if (currentProcess.RemainingTime == 0)
            {
                currentProcess.CompletionTime = time;
                currentProcess = null; // Giải phóng CPU
            }
        }
        return new SchedulingTrace ( processes, segments );
    }
}


