using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OS.Scheduling.Services
{
    public class SchedulerFactory
    {
        public SchedulerConfig CreateScheduler(
            SchedulerType type,
            PriorityMode priorityMode = PriorityMode.LowNumberHighPriority,
            int quantumTime = 2)
        {
            IScheduler scheduler = type switch
            {
                SchedulerType.FCFS => new FCFS(),
                SchedulerType.SJF => new SJF(),
                SchedulerType.SRJF => new SRJF(),
                SchedulerType.RoundRobin => new RoundRobin(quantumTime),
                SchedulerType.PriorityNonPreemptive => new PriorityNonPreemptive(
                     priorityMode == PriorityMode.LowNumberHighPriority
                         ? new LowNumberHighPriority()
                         : new HighNumberHighPriority()),
                SchedulerType.PriorityPreemptive => new PriorityPreemptive(
                    priorityMode == PriorityMode.LowNumberHighPriority
                        ? new LowNumberHighPriority()
                        : new HighNumberHighPriority()),
                _ => throw new ArgumentException("SchedulerType không hợp lệ.")
            };
            return new SchedulerConfig(scheduler);
        }
    }
}