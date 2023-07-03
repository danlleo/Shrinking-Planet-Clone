using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CloudGreetingsUI : MonoBehaviour
{
    [SerializeField] private GameObject _cloudGreetingsUI;
    [SerializeField] private TextMeshProUGUI _cloudImageText;
    [SerializeField] private Unit _unit;

    private void OnEnable()
    {
        UnitIdleState.OnUnitSpawned += UnitIdleState_OnUnitSpawned;
    }

    private void OnDestroy()
    {
        UnitIdleState.OnUnitSpawned -= UnitIdleState_OnUnitSpawned;
    }

    private void UnitIdleState_OnUnitSpawned(object sender, EventArgs e)
    {
        Unit selectedUnit = (Unit)sender;

        if (ReferenceEquals(selectedUnit, _unit))
        {
            InvokeDisplayUICloudWithTextCoroutine();
        }
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
