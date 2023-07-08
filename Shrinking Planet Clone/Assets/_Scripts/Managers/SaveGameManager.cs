using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGameManager : MonoBehaviour
{
    [SerializeField] private Unit _unitPrefab;

    public static List<Unit> UnitList = new List<Unit>();

    const string UNIT_KEY = "/unit";
    const string UNIT_COUNT_KEY = "/unit.count";

    // For testing purposes
    public void Update()
    {
        if (InputManager.Instance.IsTButtonDownThisFrame())
        {
            
        }

        if (Input.GetKeyDown(KeyCode.L))
        {

        }
    }
    
    private void Save()
    {
        string key = UNIT_KEY + SceneManager.GetActiveScene().buildIndex;
        string countKey = UNIT_COUNT_KEY + SceneManager.GetActiveScene().buildIndex;

        SaveSystem.Save(UnitList.Count, countKey);

        for (int i = 0; i < UnitList.Count; i++)
        {
            UnitData unitData = new UnitData(UnitList[i]);

            SaveSystem.Save(unitData, key + i);
        }
    }

    private void Load()
    {
        string key = UNIT_KEY + SceneManager.GetActiveScene().buildIndex;
        string countKey = UNIT_COUNT_KEY + SceneManager.GetActiveScene().buildIndex;

        int count = SaveSystem.Load<int>(countKey);

        for (int i = 0; i < count; i++)
        {
            Unit unit = Instantiate(_unitPrefab);
            UnitData unitData = SaveSystem.Load<UnitData>(key + i);
        }
    }
}
