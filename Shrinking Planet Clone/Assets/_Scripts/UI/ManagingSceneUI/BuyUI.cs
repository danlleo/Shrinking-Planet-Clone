using System;
using UnityEngine;
using UnityEngine.UI;

public class BuyUI : MonoBehaviour
{
    public static event EventHandler OnOpenBuyUIClose;

    [SerializeField] private GameObject _buyUI;
    [SerializeField] private Button _closeButton;

    private void Awake()
    {
        _closeButton.onClick.AddListener(() =>
        {
            Hide();
            OnOpenBuyUIClose?.Invoke(this, EventArgs.Empty);
        });
    }

    private void Start()
    {
        ManagingUI.OnOpenBuyUI += ManagingUI_OnOpenBuyUI;
    }

    private void OnDestroy()
    {
        ManagingUI.OnOpenBuyUI -= ManagingUI_OnOpenBuyUI;
    }

    private void ManagingUI_OnOpenBuyUI(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show() => _buyUI.SetActive(true);

    private void Hide() => _buyUI.SetActive(false);
}
