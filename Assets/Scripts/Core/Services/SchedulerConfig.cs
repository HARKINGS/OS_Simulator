using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class SchedulerConfig
{
    public IScheduler Scheduler { get; }

    public SchedulerConfig(IScheduler scheduler)
    {
        Scheduler = scheduler;
    }
}
