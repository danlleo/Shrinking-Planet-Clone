using UnityEngine;
using UnityEngine.UI;

public class JobPickUI : MonoBehaviour
{
    [SerializeField] private GameObject _jobPickUI;
    [SerializeField] private Image _occupationImage;
    [SerializeField] private Button _artButton;
    [SerializeField] private Button _supportButton;
    [SerializeField] private Button _developerButton;
    [SerializeField] private Button _moderatorButton;

    private Unit _unit;

    private void Awake()
    {
        _artButton.onClick.AddListener(() => SetUnitOccupation(UnitOccupationType.Art));

        _supportButton.onClick.AddListener(() => SetUnitOccupation(UnitOccupationType.Support));

        _developerButton.onClick.AddListener(() => SetUnitOccupation(UnitOccupationType.Developer));

        _moderatorButton.onClick.AddListener(() => SetUnitOccupation(UnitOccupationType.Moderator));
    }

    private void Start()
    {
        Unit.OnUnitSelectingJob += Unit_OnUnitSelectingJob;
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
        HideUI();
    }

    private void DayManager_OnDayEnded(object sender, System.EventArgs e)
    {
        HideUI();
    }

    private void OnDestroy()
    {
        Unit.OnUnitSelectingJob -= Unit_OnUnitSelectingJob;
        DayManager.Instance.OnDayEnded -= DayManager_OnDayEnded;
    }

    private void Unit_OnUnitSelectingJob(object sender, System.EventArgs e)
    {
        Unit unit = (Unit)sender;

        SetUnit(unit);
        ShowUI();

        // Display Unit's occupation image
        _occupationImage.sprite = unit.GetUnitOccupationImage();
    }

    private void ShowUI() => _jobPickUI.SetActive(true);

    private void HideUI() => _jobPickUI.SetActive(false);

    private void SetUnit(Unit unit) => _unit = unit;

    private void SetUnitOccupation(UnitOccupationType occupation)
    {
        if (_unit.TryGetComponent(out UnitOccupation unitOccupation))
        {
            unitOccupation.SetUnitOccupation(occupation);
            HideUI();
        }
    }
}
