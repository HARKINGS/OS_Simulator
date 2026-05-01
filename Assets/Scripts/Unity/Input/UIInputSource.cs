using UnityEngine;
using UnityEngine.UI;
using OS.Scheduling.Input;
using TMPro;

namespace OS.Scheduling.Unity.Input
{
    public class UIInputSource : MonoBehaviour, IInputSource
    {
        [SerializeField] private TMP_InputField _numProcessInput;
        [SerializeField] private ProcessInputRow[] _processRows; 

        public ProcessDto ReadProcess(int pid)
        {
            // Giả sử bạn có danh sách row theo index
            int index = pid - 1; // PID bắt đầu từ 1, index bắt đầu từ 0
            if (index < 0 || index >= _processRows.Length)
                return new ProcessDto
                {
                    Pid = pid,
                    ArrivalTime = 0,
                    BurstTime = 0,
                    Priority = 0
                };

            var row = _processRows[index];
            return new ProcessDto
            {
                Pid = pid,
                ArrivalTime = row.ArrivalTime,
                BurstTime = row.BurstTime,
                Priority = row.Priority
            };
        }

        public int ReadProcessCount()
        {
            if (int.TryParse(_numProcessInput.text, out int count))
                return count;
            return 0;
        }
    }
}
