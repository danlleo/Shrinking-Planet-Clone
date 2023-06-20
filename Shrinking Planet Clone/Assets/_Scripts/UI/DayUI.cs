using TMPro;
using UnityEngine;

public class DayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentDayText;

    private void Start()
    {
        DayManager.Instance.OnDayChanged += DayManager_OnDayChanged;
    }

    private void DayManager_OnDayChanged(object sender, System.EventArgs e)
    {
        int currentDay = DayManager.Instance.GetCurrentDay();
        _currentDayText.text = $"Current Day -> {currentDay}";
    }
}
