using OS.Scheduling.Reporting;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProcessTableOutputPanel : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private ProcessOutputRow rowPrefab;
    [SerializeField] private TMP_Text avgTatText;
    [SerializeField] private TMP_Text avgWtText;

    private readonly List<ProcessOutputRow> rows = new List<ProcessOutputRow>();

    public void RenderResult(SchedulingResult result)
    {
        if (content == null)
        {
            Debug.LogError("Content is null");
            return;
        }

        Debug.Log($"Number of result rows: {result.Rows.Count}");

        Clear();
        foreach (ProcessResultRow r in result.Rows)
        {
            var row = Instantiate(rowPrefab, content);
            row.ConvertProcessToProcessOutputRow(r);
            rows.Add(row);
        }
        avgTatText.text = $"Average Turnaround Time: {result.AvgTAT}";
        avgWtText.text = $"Average Waiting Time: {result.AvgWT}";
    }

    private void Clear()
    {
        for (int i = content.childCount - 1; i >= 0; i--)
            Destroy(content.GetChild(i).gameObject);

        rows.Clear();
    }
}
