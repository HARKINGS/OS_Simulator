using OS.Scheduling.Reporting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GanttBar : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private TMP_Text pidText;
    [SerializeField] private TMP_Text startTime;
    [SerializeField] private TMP_Text endTime;

    public void Bind(ExecutionSegment segment, Color color)
    {
        background.color = color;
        pidText.text = $"P{segment.Pid}";
        startTime.text = segment.StartTime.ToString();
        endTime.text = segment.EndTime.ToString();
    }
}