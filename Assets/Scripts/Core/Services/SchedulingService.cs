//using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace OS.Scheduling.Services
{
    public class SchedulingService
    {
        private readonly IScheduler _scheduler;
        public SchedulingService(IScheduler scheduler) => _scheduler = scheduler;

        public SchedulingTrace Run(List<ProcessDto> dtos)
        {
            if (dtos == null || !dtos.Any())
                return new SchedulingTrace(new List<Process>(), new List<ExecutionSegment>());

            var processes = dtos
                .Select(d => new Process(d))
                .OrderBy(p => p.Data.ArrivalTime)
                .ToList();       

            var answer = _scheduler.Schedule(processes);
            return answer;
        }
    }
}
