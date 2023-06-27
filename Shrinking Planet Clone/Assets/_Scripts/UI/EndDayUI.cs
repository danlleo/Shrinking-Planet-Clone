using UnityEngine;

public class EndDayUI : MonoBehaviour
{
    [SerializeField] private GameObject _endDayUI;

    private void Start()
    {
        Hide();
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
    }

    private void DayManager_OnDayEnded(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show() => _endDayUI.SetActive(true);

    private void Hide() => _endDayUI.SetActive(false);
}
