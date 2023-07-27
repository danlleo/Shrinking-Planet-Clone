using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagingUI : MonoBehaviour
{
    public static event EventHandler OnOpenBuyUI;

    [SerializeField] private GameObject _managingUI;
    [SerializeField] private TextMeshProUGUI _currentCompanyRankText;
    [SerializeField] private TextMeshProUGUI _currentDayText;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _interviewButton;

    private void Awake()
    {
        _startButton.onClick.AddListener(() =>
        {
            int companyRankPosition = SaveGameManager.Instance.GetCompanyRankPosition();
            int dayCount = SaveGameManager.Instance.GetDayCount();
            int moneyAmount = EconomyManager.Instance.GetTotalCurrentMoneyAmount();

            SaveGameManager.Instance.SaveGame(companyRankPosition, dayCount, moneyAmount);
            Loader.Load(Loader.Scene.WorkingScene);
        });

        _buyButton.onClick.AddListener(() =>
        {
            HideUI();
            OnOpenBuyUI?.Invoke(this, EventArgs.Empty);
        });

        _interviewButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.InterviewScene);
        });
    }

    private void Start()
    {
        _currentCompanyRankText.text = SaveGameManager.Instance.GetCompanyRankPosition().ToString();
        _currentDayText.text = DayManager.Instance.GetCurrentDay().ToString();
        BuyUI.OnOpenBuyUIClose += BuyUI_OnOpenBuyUIClose;

        if (IsInterviewDay())
        {
            ShowInterviewButton();
        }
        else
        {
            ShowStartButton();
        }
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
