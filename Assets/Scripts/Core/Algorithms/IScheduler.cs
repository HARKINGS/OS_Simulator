using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public interface IScheduler
{
    SchedulingTrace Schedule(List<Process> processes);
}
