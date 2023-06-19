using TMPro;
using UnityEngine;

public class CloudWorldCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cloudImageText;
    [SerializeField] private Unit _unit;

    private void Start() => UpdateCloudImageText(_unit.GetUnitGreetingsText());
    
    private void UpdateCloudImageText(string targetText) => _cloudImageText.text = targetText;
}
