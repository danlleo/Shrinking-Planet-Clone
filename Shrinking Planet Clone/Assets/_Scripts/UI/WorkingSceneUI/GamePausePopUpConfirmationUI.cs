using System;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePausePopUpConfirmationUI : MonoBehaviour
{
    [SerializeField] private GameObject _gamePausePopUpConfirmationUI;
    [SerializeField] private TextMeshProUGUI _confirmationText;
    [SerializeField] private Button _confirmationButton;
    [SerializeField] private Button _declineButton;

    private Action _buttonAction;

    private void Awake()
    {
        HideUI();

        _confirmationButton.onClick.AddListener(() =>
        {
            GameManager.Instance.Resume();
            _buttonAction?.Invoke();
        });

        _declineButton.onClick.AddListener(() =>
        {
            HideUI();
        });
    }

    private void Start()
    {
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameUnpaused -= GameManager_OnGameUnpaused;
    }

    public void Initialize(string message, Action buttonAction)
    {
        ShowUI();
        _confirmationText.text = message;
        _buttonAction = buttonAction;
    }

    private void GameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        HideUI();
    }

    private void ShowUI() => _gamePausePopUpConfirmationUI.SetActive(true);

    private void HideUI() => _gamePausePopUpConfirmationUI?.SetActive(false);
}
