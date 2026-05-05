using UnityEngine;
using TMPro;
using OS.Scheduling.Reporting;

public class ProcessOutputRow : MonoBehaviour
{
    [SerializeField] private TMP_Text pidOutput;
    [SerializeField] private TMP_Text arrivalTimeOutput;
    [SerializeField] private TMP_Text burstTimeOutput;
    [SerializeField] private TMP_Text priorityOutput;
    [SerializeField] private TMP_Text completionTimeOutput;
    [SerializeField] private TMP_Text turnaroundTimeOutput;
    [SerializeField] private TMP_Text waitingTimeOutput;

    public void ConvertProcessToProcessOutputRow(ProcessResultRow r)
    {
        pidOutput.text = r.Pid.ToString();
        arrivalTimeOutput.text = r.ArrivalTime.ToString();
        burstTimeOutput.text = r.BurstTime.ToString();
        priorityOutput.text = r.Priority.ToString();
        completionTimeOutput.text = r.CompletionTime.ToString();
        turnaroundTimeOutput.text = r.TurnaroundTime.ToString();
        waitingTimeOutput.text = r.WaitingTime.ToString();
    }    

    public string Pid => pidOutput.text;
    public int ArrivalTime => int.TryParse(arrivalTimeOutput.text, out var value) ? value : 0;
    public int BurstTime => int.TryParse(burstTimeOutput.text, out var value) ? value : 0;
    public int Priority => int.TryParse(priorityOutput.text, out var value) ? value : 0;
    public int CompletionTime => int.TryParse(completionTimeOutput.text, out var value) ? value : 0;
    public int TurnaroundTime => int.TryParse(turnaroundTimeOutput.text, out var value) ? value : 0;
    public int WaitingTime => int.TryParse(waitingTimeOutput.text, out var value) ? value : 0;
}
