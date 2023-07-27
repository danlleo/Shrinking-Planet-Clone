using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayUI : MonoBehaviour
{
    [SerializeField] private GameObject _dayUI;
    [SerializeField] private TextMeshProUGUI _currentDayText;
    [SerializeField] private Button _pauseButton;

    private void Awake()
    {
        ShowUI();

        _pauseButton.onClick.AddListener(() =>
        {
            GameManager.Instance.Pause();
        });
    }

    private void Start()
    {
        UpdateDayUI();

        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGamePaused -= GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnpaused -= GameManager_OnGameUnpaused;
        DayManager.Instance.OnDayEnded -= DayManager_OnDayEnded;
    }

    private void DayManager_OnDayEnded(object sender, System.EventArgs e)
    {
        HideUI();
    }

    private void GameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        ShowUI();
    }

    private void GameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        HideUI();
    }

    private void UpdateDayUI()
    {
        int currentDay = DayManager.Instance.GetCurrentDay();
        _currentDayText.text = $"{currentDay}";
    }

    private void ShowUI() => _dayUI.SetActive(true);

    private void HideUI() => _dayUI.SetActive(false);
}
