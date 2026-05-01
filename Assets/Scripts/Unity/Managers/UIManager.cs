using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ProcessTableInputPanel processTablePanel;
    [SerializeField] private GameObject quantumPanel;
    [SerializeField] private TMP_Dropdown algorithmDropdown;
    [SerializeField] private Button addProcessButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private Button runButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        quantumPanel.SetActive(false);
        algorithmDropdown.onValueChanged.AddListener(OnAlgorithmChanged);
        addProcessButton.onClick.AddListener(OnAddProcessClicked);
        resetButton.onClick.AddListener(OnResetClicked);
    }

    private void OnDestroy()
    {
        algorithmDropdown.onValueChanged.RemoveListener(OnAlgorithmChanged);
    }

    public void OnAddProcessClicked()
    {
        Debug.Log("Add Process button clicked");
        processTablePanel.AddProcess();
    }  
    
    public void OnResetClicked()
    {
        Debug.Log("Reset button clicked");
        processTablePanel.ClearRows();
    }    

    private void OnAlgorithmChanged(int index)
    {
        Debug.Log($"Algorithm changed to index: {index}");
        bool isRoundRobin = index == 4;
        // Assuming index 4 corresponds to Round Robin
        quantumPanel.SetActive(isRoundRobin);
    }
}
