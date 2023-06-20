using System.Collections;
using TMPro;
using UnityEngine;

public class CloudGreetingsUI : MonoBehaviour
{
    [SerializeField] private GameObject _cloudGreetingsUI;
    [SerializeField] private TextMeshProUGUI _cloudImageText;
    [SerializeField] private Unit _unit;

    private void Start()
    {
        DayManager.Instance.OnNewDayStart += DayManager_OnNewDayStart;
    }

    private void DayManager_OnNewDayStart(object sender, System.Action e)
    {
        InvokeDisplayUICloudWithTextCoroutine();
    }

    private void UpdateCloudImageText(string targetText) => _cloudImageText.text = targetText;

    private void Show() => _cloudGreetingsUI.SetActive(true);

    private void Hide() => _cloudGreetingsUI.SetActive(false);

    private void InvokeDisplayUICloudWithTextCoroutine() => StartCoroutine(DisplayUICloudWithTextCoroutine());

    private IEnumerator DisplayUICloudWithTextCoroutine()
    {
        Show();
        UpdateCloudImageText(_unit.GetUnitGreetingsText());

        yield return new WaitForSeconds(1.5f);

        Hide();
    }
}
