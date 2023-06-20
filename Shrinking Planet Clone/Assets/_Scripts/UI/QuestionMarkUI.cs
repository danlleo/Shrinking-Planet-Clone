using UnityEngine;

public class QuestionMarkUI : MonoBehaviour
{
    [SerializeField] private GameObject _questionMarkUI;
    [SerializeField] private Unit _unit;

    private void Start()
    {
        _unit.OnUnitReachedDesk += Unit_OnUnitReachedDesk;
        _unit.OnUnitBeganWork += Unit_OnUnitBeganWork;
    }

    private void Unit_OnUnitBeganWork(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void Unit_OnUnitReachedDesk(object sender, System.EventArgs e)
    {
        Show();
    }
    
    private void Show() => _questionMarkUI.SetActive(true); 

    private void Hide() => _questionMarkUI.SetActive(false);
}
