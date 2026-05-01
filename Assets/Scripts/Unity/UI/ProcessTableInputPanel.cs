using OS.Scheduling.Reporting;
using OS.Scheduling.Unity.Input;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProcessTableInputPanel : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private ProcessInputRow rowPrefab;

    private readonly List<ProcessInputRow> rows = new List<ProcessInputRow>();

    public void AddProcess()
    {
        var row = Instantiate(rowPrefab, content);
        row.Init(rows.Count + 1, this);
        rows.Add(row);
    }   
    
    public void RemoveRow(ProcessInputRow row)
    {
        if (rows.Remove(row))
        {
            Destroy(row.gameObject);
            RefreshPids();
        }    
    }    

    public void ClearRows()
    {
        foreach (var row in rows)
        {
            Destroy(row.gameObject);
        }    
        rows.Clear();
    }

    public List<ProcessDto> CollectDtos()
    {
        return rows.Select(r => r.ToDto()).ToList();
    }

    private void RefreshPids()
    {
        for (int i = 0; i < rows.Count; i++)
            rows[i].SetPid(i + 1);
    }
}
