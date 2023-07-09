using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveGameManager : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    [SerializeField] private Unit _unitPrefab;
=======
    [SerializeField] private List<UnitData> _unitDataList = new List<UnitData>();
>>>>>>> parent of b54ff3c (Added unstable save system, adding UI for choosing units for the interview)
=======
    [SerializeField] private List<UnitData> _unitDataList = new List<UnitData>();
>>>>>>> parent of 5b2dda5 (Fixing)
=======
    [SerializeField] private List<UnitData> _unitDataList = new List<UnitData>();
>>>>>>> parent of b54ff3c (Added unstable save system, adding UI for choosing units for the interview)

    private string _saveFilePath;

<<<<<<< HEAD
<<<<<<< HEAD
    const string UNIT_KEY = "/unit";
    const string UNIT_COUNT_KEY = "/unit.count";
=======
=======
>>>>>>> parent of 5b2dda5 (Fixing)
    private const string UNITS_PATH = "Units";

    private const int DEFAULT_COMPANY_RANK_POSITION = 100;
    private const int DEFAULT_DAY_COUNT = 1;
    private const int DEFAULT_MONEY_AMOUNT = 100;

    private void Awake()
    {
        _saveFilePath = Application.persistentDataPath + "/save.json";
    }
<<<<<<< HEAD
>>>>>>> parent of b54ff3c (Added unstable save system, adding UI for choosing units for the interview)
=======
>>>>>>> parent of 5b2dda5 (Fixing)

    // For testing purposes
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            NewGame();
        }
    }

    public void SaveGame()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        string key = UNIT_KEY + SceneManager.GetActiveScene().buildIndex;
        string countKey = UNIT_COUNT_KEY + SceneManager.GetActiveScene().buildIndex;
=======
=======
>>>>>>> parent of 5b2dda5 (Fixing)
        SaveData saveData = new SaveData();
        saveData.CompanyRankPosition = 100;
        saveData.DayCount = 1;
        saveData.MoneyAmount = 100;
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of b54ff3c (Added unstable save system, adding UI for choosing units for the interview)
=======
>>>>>>> parent of 5b2dda5 (Fixing)
=======
>>>>>>> parent of b54ff3c (Added unstable save system, adding UI for choosing units for the interview)

        string json = JsonUtility.ToJson(saveData);

<<<<<<< HEAD
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
=======
        File.WriteAllText(_saveFilePath, json);

        print("Game Saved");
    }

    public void LoadGame()
    {
        UnitSO[] unitSOList = Resources.LoadAll<UnitSO>(UNITS_PATH);

        if (File.Exists(_saveFilePath))
        {
>>>>>>> parent of 5b2dda5 (Fixing)
            string json = File.ReadAllText(_saveFilePath);

            JsonUtility.FromJson<SaveData>(json);

            return;
<<<<<<< HEAD
>>>>>>> parent of b54ff3c (Added unstable save system, adding UI for choosing units for the interview)
=======
>>>>>>> parent of 5b2dda5 (Fixing)
        }

        Debug.LogError("No Save File Found!");
    }

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
<<<<<<< HEAD
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
=======
>>>>>>> parent of b54ff3c (Added unstable save system, adding UI for choosing units for the interview)
}
