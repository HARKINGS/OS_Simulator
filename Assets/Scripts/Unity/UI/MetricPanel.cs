using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

namespace OS.Scheduling.UI
{
    public class MetricPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _avgTatText;
        [SerializeField] private TMP_Text _avgWtText;

        public void Render(List<Process> processes)
        {
            if (processes.Count == 0)
            {
                _avgTatText.text = "Average TAT: N/A";
                _avgWtText.text = "Average WT: N/A";
                return;
            }
            double avgTAT = processes.Average(p => p.TurnaroundTime);
            double avgWT = processes.Average(p => p.WaitingTime);
            _avgTatText.text = $"Average TAT: {avgTAT:F2}";
            _avgWtText.text = $"Average WT: {avgWT:F2}";
        }
    }
}