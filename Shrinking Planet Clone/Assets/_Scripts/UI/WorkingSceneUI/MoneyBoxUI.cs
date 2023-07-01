using System.Collections;
using TMPro;
using UnityEngine;
using static UnitWorkingState;

public class MoneyBoxUI : MonoBehaviour
{
    [SerializeField] private GameObject _moneyBoxUI;
    [SerializeField] private Transform _moneyIconPrefab;
    [SerializeField] private Transform _moneyIcon;
    [SerializeField] private TextMeshProUGUI _moneyAmountText;

    private float _moveDuration = .3f;

    private void Start()
    {
        OnUnitReceivedPayment += UnitWorkingState_OnUnitReceivedPayment;
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
    }

    private void DayManager_OnDayEnded(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UnitWorkingState_OnUnitReceivedPayment(object sender, UnitRecievedPaymentEventArgs e)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(MouseWorld.GetPosition());

        Transform moneyIcon = Instantiate(_moneyIconPrefab, _moneyBoxUI.transform);

        moneyIcon.transform.position = screenPosition;

        StartCoroutine(MoveIconToFinalPosition(moneyIcon));

        // Display total current money amount text
        _moneyAmountText.text = EconomyManager.Instance.GetTotalCurrentMoneyAmount().ToString();
    }

    private IEnumerator MoveIconToFinalPosition(Transform icon)
    {
        float elapsedTime = 0f;

        Vector3 startPosition = icon.transform.position;
        Vector3 endPosition = _moneyIcon.position;

        while (elapsedTime < _moveDuration)
        {
            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime / _moveDuration);

            icon.position = Vector3.Lerp(startPosition, endPosition, InterpolateUtils.EaseInOutQuart(t));

            yield return null;
        }

        Destroy(icon.gameObject);
    }

    private void Show() => _moneyBoxUI.SetActive(true);

    private void Hide() => _moneyBoxUI.SetActive(false);
}
