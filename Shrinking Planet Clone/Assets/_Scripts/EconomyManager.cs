using System;
using System.Collections;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    [SerializeField] private Transform _moneyIconPrefab;
    [SerializeField] private Transform _canvasUI;
    [SerializeField] private Transform _moneyBoxUI;

    private int _totalCurrentMoneyAmount;

    private float _moveDuration = .3f;

    private void Start()
    {
        UnitWorkingState.OnUnitReceivedPayment += UnitWorkingState_OnUnitReceivedPayment;
    }

    private void UnitWorkingState_OnUnitReceivedPayment(object sender, EventArgs e)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(MouseWorld.GetPosition());

        Transform moneyIcon = Instantiate(_moneyIconPrefab, _canvasUI);

        moneyIcon.transform.position = screenPosition;

        StartCoroutine(MoveIconToFinalPosition(moneyIcon));
    }

    private IEnumerator MoveIconToFinalPosition(Transform icon)
    {
        float elapsedTime = 0f;

        Vector3 startPosition = icon.transform.position;
        Vector3 endPosition = _moneyBoxUI.transform.position;

        while (elapsedTime < _moveDuration)
        {
            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime / _moveDuration);

            icon.position = Vector3.Lerp(startPosition, endPosition, InterpolateUtils.EaseInOutQuart(t));

            yield return null;
        }
    }
}
