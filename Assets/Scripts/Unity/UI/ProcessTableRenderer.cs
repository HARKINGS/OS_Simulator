using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

namespace OS.Scheduling.UI
{
    public class ProcessTableRenderer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _header;
        [SerializeField] private Transform _rowContainer;
        [SerializeField] private GameObject _resultRowPrefab;

        public void Render(List<Process> processes)
        {
            // Clear old rows
            foreach (Transform child in _rowContainer)
                Destroy(child.gameObject);

            // Set header
            _header.text = "\tPID\tAT\tBurst\tRemaining\tCompletion\tWaiting\tTurnaround";

            double avgTAT = 0, avgWT = 0;
            foreach (var process in processes.OrderBy(p => p.Data.Pid))
            {
                avgTAT += process.TurnaroundTime;
                avgWT += process.WaitingTime;

                var row = Instantiate(_resultRowPrefab, _rowContainer);
                var text = row.GetComponent<TMP_Text>();
                text.text = $"\t{process.Data.Pid}" +
                            $"\t{process.Data.ArrivalTime}" +
                            $"\t{process.Data.BurstTime}" +
                            $"\t{process.Data.Priority}" +
                            $"\t{process.RemainingTime}" +
                            $"\t{process.CompletionTime}" +
                            $"\t{process.WaitingTime}" +
                            $"\t{process.TurnaroundTime}";
            }
        }
    }
}
