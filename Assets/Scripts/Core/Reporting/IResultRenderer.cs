using System.Collections.Generic;
using UnityEngine;

namespace OS.Scheduling.Reporting
{
    public interface IResultRenderer
    {
        void RenderProcessList(List<Process> processes, string algoName);
        void RenderGantt(List<Process> processes);
    }
}