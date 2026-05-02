using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputNotificationPopup : MonoBehaviour
{
    [SerializeField] private TMP_Text notificationText;
    [SerializeField] private Button closeButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
        closeButton.onClick.AddListener(ClosePopup);
    }

    public void ShowPopup(string message)
    {
        notificationText.text = message;
        gameObject.SetActive(true);
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}
