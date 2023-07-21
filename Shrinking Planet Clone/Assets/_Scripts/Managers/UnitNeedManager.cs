using UnityEngine;

public class UnitNeedManager : Singleton<UnitNeedManager>
{
    private string[] _needs = new string[3];

    protected override void Awake()
    {
        base.Awake();

        _needs[0] = "Water";
        _needs[1] = "Documents";
        _needs[2] = "Trash";
    }

    public string GetRandomNeed() => _needs[Random.Range(0, _needs.Length)];
}
