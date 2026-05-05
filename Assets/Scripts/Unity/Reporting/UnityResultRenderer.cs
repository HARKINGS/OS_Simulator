using System.Collections.Generic;
using UnityEngine;
using OS.Scheduling.Reporting;
using OS.Scheduling.UI;

namespace OS.Scheduling.Unity.Reporting
{
    public class UnityResultRenderer : MonoBehaviour, IResultRenderer
    {
        [SerializeField] private GanttChartRenderer _ganttChart;

        public void RenderGantt(SchedulingResult result)
        {
            _ganttChart.Render(result);
        }
    }
}
