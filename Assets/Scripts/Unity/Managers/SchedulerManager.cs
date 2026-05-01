using OS.Scheduling.Unity.Reporting;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using OS.Scheduling.Services;

namespace OS.Scheduling.Unity.Managers
{
    public class SchedulerManager : MonoBehaviour
    {
        [SerializeField] private UnityResultRenderer _resultRenderer;

        private SchedulerFactory _schedulerFactory;
        private SchedulingService _schedulingService;

        private void Awake()
        {
            _schedulerFactory = new SchedulerFactory();
        }

        public void Run(
            SchedulerType type, 
            PriorityMode priorityMode, 
            List<ProcessDto> processDtos,
            int quantumTime = 2)
        {
            var config = _schedulerFactory.CreateScheduler(
                type, 
                priorityMode, 
                quantumTime);

            var processes = _schedulingService.Run(processDtos); // Run xong 1 lần, không step

            _resultRenderer.RenderGantt(processes);
            _resultRenderer.RenderProcessList(processes, config.ToString());
        }
    }
}