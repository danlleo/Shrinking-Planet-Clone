using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitSO _unitSO;

    public string GetGreetingsSO() => _unitSO.Greetings;

    public Vector3 GetUnitDeskPosition() => _unitSO.UnitTargetDeskPosition;

    private BaseAction[] _baseActionArray;

    private void Awake()
    {
        _baseActionArray = GetComponents<BaseAction>();
    }

    private void Start()
    {
        BaseAction baseAction = GetComponent<BaseAction>();
    }

    public T GetAction<T>() where T : BaseAction
    {
        foreach (BaseAction baseAction in _baseActionArray)
        {
            if (baseAction is T t)
                return t;
        }

        return null;
    }
}
