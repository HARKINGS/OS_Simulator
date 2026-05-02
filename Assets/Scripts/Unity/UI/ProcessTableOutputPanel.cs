using OS.Scheduling.Reporting;
using OS.Scheduling.Unity.Input;
using OS.Scheduling.Unity.Managers;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ProcessTableOutputPanel : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private ProcessOutputRow rowPrefab;
    [SerializeField] private TMP_InputField numProcessInput;

    private readonly List<ProcessOutputRow> rows = new List<ProcessOutputRow>();

    //private void Start()
    //{
    //    UpdateNumInput();
    //    numProcessInput.onEndEdit.AddListener(OnNumProcessChanged);
    //}

    //public void AddProcess()
    //{
    //    var row = Instantiate(rowPrefab, content);
    //    row.Init(rows.Count + 1, this);
    //    rows.Add(row);
    //    UpdateNumInput();
    //}

    //public void RemoveRow(ProcessInputRow row)
    //{
    //    if (rows.Remove(row))
    //    {
    //        Destroy(row.gameObject);
    //        RefreshPids();
    //    }
    //    UpdateNumInput();
    //}

    //public void ClearRows()
    //{
    //    foreach (var row in rows)
    //    {
    //        Destroy(row.gameObject);
    //    }
    //    rows.Clear();
    //    UpdateNumInput();
    //}

    //public void Run(out string message)
    //{
    //    if (!TryCollectDtos(out List<ProcessDto> dtos, out message))
    //        return;

    //    foreach (var dto in dtos)
    //        Debug.Log($"{dto.Pid} {dto.ArrivalTime} {dto.BurstTime} {dto.Priority}");
    //}

    //public bool TryCollectDtos(out List<ProcessDto> dtos, out string message)
    //{
    //    dtos = new List<ProcessDto>();
    //    var errors = new List<string>();

    //    if (rows.Count == 0)
    //    {
    //        message = "No processes available.";
    //        return false;
    //    }

    //    foreach (var row in rows)
    //    {
    //        bool ok = row.TryGetDto(out var dto, out var error);
    //        if (!ok) Debug.LogError($"Row {row.PID} error: {error}");
    //        if (ok)
    //            dtos.Add(dto);
    //        else
    //            errors.Add(error);
    //    }

    //    if (errors.Count > 0)
    //    {
    //        message = string.Join("\n", errors);
    //        return false;
    //    }

    //    message = "";
    //    return true;
    //}

    //private void RefreshPids()
    //{
    //    for (int i = 0; i < rows.Count; i++)
    //        rows[i].SetPid(i + 1);
    //}
    //private void UpdateNumInput()
    //{
    //    numProcessInput.text = rows.Count.ToString();
    //}
    //private void OnNumProcessChanged(string value)
    //{
    //    if (int.TryParse(value, out int targetCount))
    //    {
    //        AdjustProcessRows(targetCount);
    //    }
    //}
    //private void AdjustProcessRows(int targetCount)
    //{
    //    int currentCount = rows.Count;
    //    if (targetCount > currentCount)
    //    {
    //        for (int i = currentCount; i < targetCount; i++)
    //            AddProcess();
    //    }
    //    else if (targetCount < currentCount)
    //    {
    //        for (int i = currentCount - 1; i >= targetCount; i--)
    //            RemoveRow(rows[i]);
    //    }
    //}
}
