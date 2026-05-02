using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace OS.Scheduling.Unity.Input
{
    public class ProcessInputRow : MonoBehaviour
    {
        [SerializeField] private TMP_Text pidText;
        [SerializeField] private TMP_InputField _arrivalInput;
        [SerializeField] private TMP_InputField _burstInput;
        [SerializeField] private TMP_InputField _priorityInput;
        [SerializeField] private Button _removeButton;

        private int _pid;
        private ProcessTableInputPanel _owner;

        public void Init(int pid, ProcessTableInputPanel owner)
        {
            _pid = pid;
            _owner = owner;
            pidText.text = $"P{pid}";
            _removeButton.onClick.RemoveAllListeners();
            _removeButton.onClick.AddListener(() => _owner.RemoveRow(this));
        }

        public bool TryGetDto(out ProcessDto dto, out string error)
        {
            dto = null;
            error = "";

            if (ArrivalTime < 0)
            {
                error = $"P{_pid}: Arrival Time phải >= 0";
                return false;
            }

            if (BurstTime <= 0)
            {
                error = $"P{_pid}: Burst Time phải > 0";
                return false;
            }

            if (Priority < 0)
            {
                error = $"P{_pid}: Priority phải >= 0";
                return false;
            }

            dto = new ProcessDto
            {
                Pid = _pid,
                ArrivalTime = ArrivalTime,
                BurstTime = BurstTime,
                Priority = Priority
            };
            return true;
        }

        public void SetPid(int pid)
        {
            _pid = pid;
            pidText.text = $"P{pid}";
        }

        public string PID => $"P{_pid}";
        public int ArrivalTime => int.TryParse(_arrivalInput.text, out var value) ? value : 0;
        public int BurstTime => int.TryParse(_burstInput.text, out var value) ? value : 0;
        public int Priority => int.TryParse(_priorityInput.text, out var value) ? value : 0;

        public object Data { get; internal set; }
    }
}