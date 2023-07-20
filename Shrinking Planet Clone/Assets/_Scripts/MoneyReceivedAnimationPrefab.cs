using TMPro;
using UnityEngine;

public class MoneyReceivedAnimationPrefab : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyReceivedText;

    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    public void SetMoneyReceivedText(int moneyAmount)
    {
        _moneyReceivedText.text = "$" + moneyAmount.ToString();
    }
}
