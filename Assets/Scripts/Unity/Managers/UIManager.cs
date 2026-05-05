using OS.Scheduling.Reporting;
using OS.Scheduling.Unity.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas inputScene;
    [SerializeField] private Canvas outputScene;    

    [SerializeField] private ProcessTableInputPanel processTableInputPanel;
    [SerializeField] private ProcessTableOutputPanel processTableOutputPanel;

    [SerializeField] private SchedulerManager schedulerManager;

    [SerializeField] private GameObject quantumPanel;
    [SerializeField] private GameObject priorityPanel;
    [SerializeField] private GameObject preemptivePanel;
    [SerializeField] private GameObject inputNotificationPopup;

    [SerializeField] private TMP_Dropdown algorithmDropdown;
    [SerializeField] private TMP_InputField quantumInput;
    [SerializeField] private TMP_Dropdown priorityDropdown;
    [SerializeField] private TMP_Dropdown preemptiveDropdown;

    [SerializeField] private Button addProcessButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private Button runButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button exitButton;

    public int GetQuantumTime()
    {
        if(int.TryParse(quantumInput.text, out int quantum) && quantum > 0)
            return quantum;
        return 0;
    }   
    
    public SchedulerType GetSelectedAlgorithm()
    {
        // Priority option is index 4 (matches OnAlgorithmChanged logic).
        if (algorithmDropdown.value == 4)
        {
            if (preemptiveDropdown.value == 0)
                return SchedulerType.PriorityPreemptive;
            return SchedulerType.PriorityNonPreemptive;
        }    
        // Cast the selected dropdown value to the enum instead of attempting to invoke the type.
        return (SchedulerType)algorithmDropdown.value;
    }

    public PriorityMode GetPriorityMode()
    {
        if (priorityDropdown == null)
        {
            Debug.LogError("Priority dropdown not found in priorityPanel");
            return PriorityMode.LowNumberHighPriority;
        }

        return priorityDropdown.value == 1
            ? PriorityMode.HighNumberHighPriority
            : PriorityMode.LowNumberHighPriority;
    }

    private void Start()
    {
        inputScene.gameObject.SetActive(true);
        outputScene.gameObject.SetActive(false);

        quantumPanel.SetActive(false);
        priorityPanel.SetActive(false);
        preemptivePanel.SetActive(false);

        algorithmDropdown.onValueChanged.AddListener(OnAlgorithmChanged);
        addProcessButton.onClick.AddListener(OnAddProcessClicked);
        resetButton.onClick.AddListener(OnResetClicked);
        runButton.onClick.AddListener(OnRunClicked);
        backButton.onClick.AddListener(OnBackButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnDestroy()
    {
        algorithmDropdown.onValueChanged.RemoveListener(OnAlgorithmChanged);
    }

    public void OnAddProcessClicked()
    {
        Debug.Log("Add Process button clicked");
        processTableInputPanel.AddProcess();
    }    
    
    public void OnResetClicked()
    {
        Debug.Log("Reset button clicked");
        processTableInputPanel.ClearRows();
    }    

    public void OnRunClicked()
    {
        Debug.Log("Run button clicked");

        if (!processTableInputPanel.TryCollectDtos(out var dtos, out string message))
        {
            inputNotificationPopup.GetComponent<InputNotificationPopup>().ShowPopup(message);
            return;
        }

        if (!TryBuildConfig(out var type, out var priorityMode, out var quantum, out var configError))
        {
            inputNotificationPopup.GetComponent<InputNotificationPopup>().ShowPopup(configError);
            return;
        }

        if (algorithmDropdown.value == 3 && GetQuantumTime() <= 0)
        {     
            inputNotificationPopup.GetComponent<InputNotificationPopup>().ShowPopup("Quantumtime phải > 0!");
            return;
        }

        SchedulingResult result = schedulerManager.Run(type, priorityMode, dtos, quantum);
        ShowResult(result);
    }

    public void OnBackButtonClicked()
    {
        Debug.Log("Back button clicked");
        outputScene.gameObject.SetActive(false);
        inputScene.gameObject.SetActive(true);
    }

    public void OnExitButtonClicked()
    {
        Debug.Log("Exit button clicked");
        Application.Quit();
    }

    private void ShowResult(SchedulingResult result)
    {
        inputScene.gameObject.SetActive(false);
        outputScene.gameObject.SetActive(true);
        processTableOutputPanel.RenderResult(result);
    }

    private void OnAlgorithmChanged(int index)
    {
        Debug.Log($"Algorithm changed to index: {index}");
        bool isRoundRobin = index == 3;
        bool isPriority = index == 4;
      
        priorityPanel.SetActive(isPriority);
        preemptivePanel.SetActive(isPriority);
        quantumPanel.SetActive(isRoundRobin);
    }

    private bool TryBuildConfig(out SchedulerType type, out PriorityMode priorityMode, out int quantum, out string error)
    {
        type = GetSelectedAlgorithm();
        priorityMode = GetPriorityMode();
        quantum = GetQuantumTime();
        error = "";
        if (type == SchedulerType.RoundRobin && quantum <= 0)
        {
            error = "Quantum time must be greater than 0 for Round Robin algorithm.";
            return false;
        }
        return true;
    }
}
