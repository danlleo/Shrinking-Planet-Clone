using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationMessageUI : MonoBehaviour
{
    [SerializeField] private GameObject _confirmationMessageUI;
    [SerializeField] private TextMeshProUGUI _confirmationMessageText;
    [SerializeField] private Button _confirmationButton;

    private void Awake()
    {
        HideUI();

        _confirmationButton.onClick.AddListener(() =>
        {
            HideUI();
        });
    }

    private void Start()
    {
        ShopManager.Instance.OnItemBought += ShopManager_OnItemBought;
        ShopManager.Instance.OnItemFailedPurchase += ShopManager_OnItemFailedPurchase;
    }

    private void OnDestroy()
    {
        ShopManager.Instance.OnItemBought -= ShopManager_OnItemBought;
        ShopManager.Instance.OnItemFailedPurchase -= ShopManager_OnItemFailedPurchase;
    }

    private void ShopManager_OnItemFailedPurchase(object sender, System.EventArgs e)
    {
        ShowUI();
        SetConfirmationMessageText("Failed to purchase!");
    }

    private void ShopManager_OnItemBought(object sender, System.EventArgs e)
    {
        ShowUI();
        SetConfirmationMessageText("Purchased!");
    }

    private void ShowUI() => _confirmationMessageUI.SetActive(true);

    private void HideUI() => _confirmationMessageUI.SetActive(false);

    private void SetConfirmationMessageText(string message) => _confirmationMessageText.text = message; 
}
