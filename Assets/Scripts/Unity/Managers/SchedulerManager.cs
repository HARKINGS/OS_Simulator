using OS.Scheduling.Unity.Reporting;
using System.Collections.Generic;
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

            _schedulingService = new SchedulingService(config.Scheduler);
            var processes = _schedulingService.Run(processDtos); // Run xong 1 lần, không step

            foreach (var process in processes)
            {
                Debug.Log($"Process {process.Data.Pid}: " +
                    $"ArrivalTime={process.Data.ArrivalTime}, " +
                    $"BurstTime={process.Data.BurstTime}, " +
                    $"Priority={process.Data.Priority}, " +
                    $"CompletionTime={process.CompletionTime}, " +
                    $"TurnAroundTime={process.TurnaroundTime}, " +
                    $"WaitingTime={process.WaitingTime}");
            }

            //_resultRenderer.RenderGantt(processes);
            //_resultRenderer.RenderProcessList(processes, config.ToString());
        }
    }
}