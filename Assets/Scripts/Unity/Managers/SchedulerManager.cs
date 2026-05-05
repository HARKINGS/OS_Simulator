using OS.Scheduling.Unity.Reporting;
using System.Collections.Generic;
using UnityEngine;
using OS.Scheduling.Services;
using OS.Scheduling.Reporting;

namespace OS.Scheduling.Unity.Managers
{
    public class SchedulerManager : MonoBehaviour
    {
        [SerializeField] private UnityResultRenderer _resultRenderer;
        [SerializeField] private ResultReporter _resultReporter;

        private SchedulerFactory _schedulerFactory;
        private SchedulingService _schedulingService;

        private void Awake()
        {
            _schedulerFactory = new SchedulerFactory();
            _resultReporter = new ResultReporter();
        }

        public SchedulingResult Run(SchedulerType type, PriorityMode mode, List<ProcessDto> processDtos, int quantumTime = 2)
        {
            var config = _schedulerFactory.CreateScheduler(type, mode, quantumTime);

            _schedulingService = new SchedulingService(config.Scheduler);
            var trace = _schedulingService.Run(processDtos); // Run xong 1 lần, không step
            var result = _resultReporter.Calculate(trace);

            foreach (var process in trace.Processes)
            {
                Debug.Log($"Process {process.Data.Pid}: " +
                    $"ArrivalTime={process.Data.ArrivalTime}, " +
                    $"BurstTime={process.Data.BurstTime}, " +
                    $"Priority={process.Data.Priority}, " +
                    $"CompletionTime={process.CompletionTime}, " +
                    $"TurnAroundTime={process.TurnaroundTime}, " +
                    $"WaitingTime={process.WaitingTime}");
            }

            _resultRenderer.RenderGantt(result);

            return result;
        }
    }
}