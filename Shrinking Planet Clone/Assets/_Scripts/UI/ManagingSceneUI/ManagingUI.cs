using System;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagingUI : MonoBehaviour
{
    public static event EventHandler OnOpenBuyUI;

    [SerializeField] private GameObject _managingUI;
    [SerializeField] private ManagingPopUpWindowUI _managingPopUpWindowUI;
    [SerializeField] private MessagePopUpWindowUI _messagePopUpWindowUI;
    [SerializeField] private TextMeshProUGUI _currentCompanyRankText;
    [SerializeField] private TextMeshProUGUI _currentDayText;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _interviewButton;
    [SerializeField] private Button _mainMenuButton;

    private void Awake()
    {
        _startButton.onClick.AddListener(() =>
        {
            _managingPopUpWindowUI.Initialize("Are you sure you want to start a new working day?", () =>
            {
                int companyRankPosition = SaveGameManager.Instance.GetCompanyRankPosition();
                int dayCount = SaveGameManager.Instance.GetDayCount();
                int moneyAmount = EconomyManager.Instance.GetTotalCurrentMoneyAmount();

                SaveGameManager.Instance.SaveGame(companyRankPosition, dayCount, moneyAmount);
                Loader.Load(Loader.Scene.WorkingScene);
            });
        });

        _buyButton.onClick.AddListener(() =>
        {
            HideUI();
            OnOpenBuyUI?.Invoke(this, EventArgs.Empty);
        });

        _interviewButton.onClick.AddListener(() =>
        {
            int price = CompanyProgress.GetInterviewPrice(SaveGameManager.Instance.GetCompanyRankPosition());

            _managingPopUpWindowUI.Initialize($"In order to proceed you have to pay: {price}, are you ready?", () =>
            {
                if (EconomyManager.Instance.GetTotalCurrentMoneyAmount() >= price)
                {
                    EconomyManager.Instance.SubstractCurrentMoneyAmountBy(price);
                    SaveGameManager.Instance.SaveGame(
                            SaveGameManager.Instance.GetCompanyRankPosition(),
                            DayManager.Instance.GetCurrentDay(),
                            EconomyManager.Instance.GetTotalCurrentMoneyAmount()
                        );
                    Loader.Load(Loader.Scene.InterviewScene);

                    return;
                }

                _messagePopUpWindowUI.InvokeMessageWindowPopUp("Not enough money for an interview");
                _managingPopUpWindowUI.HideUI();
            });
        });

        _mainMenuButton.onClick.AddListener(() =>
        {
            _managingPopUpWindowUI.Initialize("Are you sure you wanna go back to the Main Menu?", () =>
            {
                Loader.Load(Loader.Scene.MainMenuScene);
            });
        });
    }

    private void Start()
    {
        _currentCompanyRankText.text = SaveGameManager.Instance.GetCompanyRankPosition().ToString();
        _currentDayText.text = DayManager.Instance.GetCurrentDay().ToString();
        BuyUI.OnOpenBuyUIClose += BuyUI_OnOpenBuyUIClose;

        if (IsInterviewDay())
            ShowInterviewButton();
        
        ShowStartButton();    
    }

    private bool IsInterviewDay() => DayManager.Instance.GetCurrentDay() % 4 == 0;

    private void OnDestroy()
    {
        BuyUI.OnOpenBuyUIClose -= BuyUI_OnOpenBuyUIClose;
    }

    private void BuyUI_OnOpenBuyUIClose(object sender, EventArgs e)
    {
        ShowUI();
    }

    private void ShowUI() => _managingUI.SetActive(true);

    private void HideUI() => _managingUI.SetActive(false);

    private void ShowStartButton() => _startButton.gameObject.SetActive(true);

    private void ShowInterviewButton() => _interviewButton.gameObject.SetActive(true);
}
