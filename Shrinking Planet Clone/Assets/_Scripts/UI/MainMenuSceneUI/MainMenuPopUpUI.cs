using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenuSceneUI
{
    public class MainMenuPopUpUI : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenuPopUpUI;
        [SerializeField] private TextMeshProUGUI _messageText;
        [SerializeField] private Button _confirmationButton;
        [SerializeField] private Button _declineButton;

        private Action _buttonAction;

        private void Awake()
        {
            HideUI();

            _confirmationButton.onClick.AddListener(() =>
            {
                _buttonAction?.Invoke();
            });

            _declineButton.onClick.AddListener(HideUI);
        }

        public void Initialize(string message, Action buttonAction)
        {
            ShowUI();

            _messageText.text = message;
            _buttonAction = buttonAction;
        }

        private void ShowUI() => _mainMenuPopUpUI.SetActive(true);

        private void HideUI() => _mainMenuPopUpUI.SetActive(false);
    }
}
