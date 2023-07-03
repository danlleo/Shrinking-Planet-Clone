using System.Collections.Generic;

public class UnitManager : Singleton<UnitManager>
{
    private List<Unit> _unitList = new List<Unit>();
    
    protected override void Awake()
    {
        base.Awake();
    }

    public void AddUnit(Unit unit) => _unitList.Add(unit);

    public List<Unit> GetAllUnits() => _unitList;
}
