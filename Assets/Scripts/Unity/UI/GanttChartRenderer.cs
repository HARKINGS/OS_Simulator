using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

namespace OS.Scheduling.UI
{
    public class GanttChartRenderer : MonoBehaviour
    {
        [SerializeField] private RectTransform _ganttArea;
        [SerializeField] private GameObject _ganttBarPrefab; /// Image + Text

        public void Render(List<Process> processes)
        {
            // Clear old bars
            foreach (Transform child in _ganttArea)
            {
                Destroy(child.gameObject);
            }

            int time = 0;
            var sorted = processes.OrderBy(p => p.CompletionTime).ToList();

            // Create new bars
            foreach (Process process in sorted)
            {
                int start = time;
                int end = process.CompletionTime;
                int duration = end - start;

                var bar = Instantiate(_ganttBarPrefab, _ganttArea);
                var rect = bar.GetComponent<RectTransform>();

                // Position & width theo duration (ví dụ 1 unit = 20px)
                float scale = 20f;
                rect.anchoredPosition = new Vector2(start * scale, 0);
                rect.sizeDelta = new Vector2(duration * scale, rect.sizeDelta.y);

                // Gán text PID
                var pidText = bar.GetComponentInChildren<Text>();
                pidText.text = $"P{process.Data.Pid}";

                time = end; // Cập nhật thời gian cho process tiếp theo
            }
        }
    }
}
