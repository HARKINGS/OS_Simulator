using System.Collections.Generic;
using UnityEngine;

namespace OS.Scheduling.Reporting
{
    public interface IResultRenderer
    {
        void RenderGantt(SchedulingResult result);
    }
}