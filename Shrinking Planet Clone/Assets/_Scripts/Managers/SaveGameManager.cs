using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGameManager : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private Unit _unitPrefab;
=======
    [SerializeField] private List<UnitData> _unitDataList = new List<UnitData>();
>>>>>>> parent of b54ff3c (Added unstable save system, adding UI for choosing units for the interview)

    public static List<Unit> UnitList = new List<Unit>();

<<<<<<< HEAD
    const string UNIT_KEY = "/unit";
    const string UNIT_COUNT_KEY = "/unit.count";
=======
    private const string UNITS_PATH = "Units";

    private const int DEFAULT_COMPANY_RANK_POSITION = 100;
    private const int DEFAULT_DAY_COUNT = 1;
    private const int DEFAULT_MONEY_AMOUNT = 100;

    private void Awake()
    {
        _saveFilePath = Application.persistentDataPath + "/save.json";
    }
>>>>>>> parent of b54ff3c (Added unstable save system, adding UI for choosing units for the interview)

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
<<<<<<< HEAD
        string key = UNIT_KEY + SceneManager.GetActiveScene().buildIndex;
        string countKey = UNIT_COUNT_KEY + SceneManager.GetActiveScene().buildIndex;
=======
        SaveData saveData = new SaveData();
        saveData.CompanyRankPosition = 100;
        saveData.DayCount = 1;
        saveData.MoneyAmount = 100;
>>>>>>> parent of b54ff3c (Added unstable save system, adding UI for choosing units for the interview)

        int count = SaveSystem.Load<int>(countKey);

<<<<<<< HEAD
        for (int i = 0; i < count; i++)
        {
            Unit unit = Instantiate(_unitPrefab);
            UnitData unitData = SaveSystem.Load<UnitData>(key + i);
=======
        File.WriteAllText(_saveFilePath, json);

        print("Game Saved");
    }

    public void LoadGame()
    {
        UnitSO[] unitSOList = Resources.LoadAll<UnitSO>(UNITS_PATH);

        if (File.Exists(_saveFilePath))
        {
            string json = File.ReadAllText(_saveFilePath);

            JsonUtility.FromJson<SaveData>(json);

            return;
>>>>>>> parent of b54ff3c (Added unstable save system, adding UI for choosing units for the interview)
        }
    }
<<<<<<< HEAD
=======

    public void NewGame()
    {
        if (File.Exists(_saveFilePath))
        {
            File.Delete(_saveFilePath);
        }

        _unitDataList.Clear();

        SaveData saveData = new SaveData();
        saveData.CompanyRankPosition = DEFAULT_COMPANY_RANK_POSITION;
        saveData.DayCount = DEFAULT_DAY_COUNT;
        saveData.MoneyAmount = DEFAULT_MONEY_AMOUNT;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText( _saveFilePath, json);

        print("New Game Started");
    }
>>>>>>> parent of b54ff3c (Added unstable save system, adding UI for choosing units for the interview)
}
