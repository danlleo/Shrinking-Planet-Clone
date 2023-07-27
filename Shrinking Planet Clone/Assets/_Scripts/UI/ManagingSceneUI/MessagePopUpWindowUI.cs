using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessagePopUpWindowUI : MonoBehaviour
{
    [SerializeField] private GameObject _messagePopUpWindowUI;
    [SerializeField] private TextMeshProUGUI _messageText;
    [SerializeField] private Button _confirmButton;

    private void Awake()
    {
        HideUI();

        _confirmButton.onClick.AddListener(() =>
        {
            HideUI();
        });
    }

    public void InvokeMessageWindowPopUp(string message)
    {
        ShowUI();
        _messageText.text = message;
    }

    private void ShowUI() => _messagePopUpWindowUI.SetActive(true);

    private void HideUI() => _messagePopUpWindowUI.SetActive(false);
}
