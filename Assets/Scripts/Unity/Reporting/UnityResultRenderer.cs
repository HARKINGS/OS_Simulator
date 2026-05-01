using System.Collections.Generic;
using UnityEngine;
using OS.Scheduling.Reporting;
using OS.Scheduling.UI;

namespace OS.Scheduling.Unity.Reporting
{
    public class UnityResultRenderer : MonoBehaviour, IResultRenderer
    {
        [SerializeField] private ProcessTableRenderer _processTable;
        [SerializeField] private GanttChartRenderer _ganttChart;
        [SerializeField] private MetricPanel _metricPanel;

        public void RenderGantt(List<Process> processes)
        {
            _ganttChart.Render(processes);
        }

        public void RenderProcessList(List<Process> processes, string algoName)
        {
            _processTable.Render(processes);
        }
    }
}
