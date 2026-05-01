using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public interface IScheduler
{
    void Schedule(List<Process> processes);
}
