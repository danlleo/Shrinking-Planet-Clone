using UnityEngine;
using UnityEngine.UI;

public class JobPickUI : MonoBehaviour
{
    [SerializeField] private GameObject _jobPickUI;
    [SerializeField] private Button _artButton;
    [SerializeField] private Button _supportButton;
    [SerializeField] private Button _developerButton;
    [SerializeField] private Button _moderatorButton;

    private Unit _unit;

    private void Awake()
    {
        _artButton.onClick.AddListener(() => SetUnitOccupation(UnitOccupationTypes.Art));

        _supportButton.onClick.AddListener(() => SetUnitOccupation(UnitOccupationTypes.Support));

        _developerButton.onClick.AddListener(() => SetUnitOccupation(UnitOccupationTypes.Developer));

        _moderatorButton.onClick.AddListener(() => SetUnitOccupation(UnitOccupationTypes.Moderator));
    }

    private void Start()
    {
        Unit.OnUnitSelectingJob += Unit_OnUnitSelectingJob;
        Hide();
    }

    private void OnDestroy()
    {
        Unit.OnUnitSelectingJob -= Unit_OnUnitSelectingJob;
    }

    private void Unit_OnUnitSelectingJob(object sender, System.EventArgs e)
    {
        Unit unit = (Unit)sender;

        SetUnit(unit);
        Show();
    }

    private void Show() => _jobPickUI.SetActive(true);

    private void Hide() => _jobPickUI.SetActive(false);

    private void SetUnit(Unit unit) => _unit = unit;

    private void SetUnitOccupation(UnitOccupationTypes occupation)
    {
        if (_unit.TryGetComponent(out UnitOccupation unitOccupation))
        {
            unitOccupation.SetUnitOccupation(occupation);
            Hide();
        }
    }
}
