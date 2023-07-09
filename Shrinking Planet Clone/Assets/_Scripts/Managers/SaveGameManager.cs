using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveGameManager : Singleton<SaveGameManager>
{
    [SerializeField] private List<UnitData> _defaultUnitDataList = new List<UnitData>();
    
    private List<UnitData> _unitDataList = new List<UnitData>();

    private string _saveFilePath;

    private const string UNITS_PATH = "Units";

    private const int DEFAULT_COMPANY_RANK_POSITION = 100;
    private const int DEFAULT_DAY_COUNT = 1;
    private const int DEFAULT_MONEY_AMOUNT = 100;

    protected override void Awake()
    {
        base.Awake();

        _saveFilePath = Application.persistentDataPath + "/save.json";
        
        if (SaveExists())
        {
            LoadGame();
        }
        else
        {
            NewGame();
        }
    }

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
        SaveData saveData = new SaveData();
        saveData.CompanyRankPosition = 100;
        saveData.DayCount = 1;
        saveData.MoneyAmount = 100;
        saveData.UnitDataList = _unitDataList;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(_saveFilePath, json);

        print("Game Saved");
    }

    public void LoadGame()
    {
        if (File.Exists(_saveFilePath))
        {
            string json = File.ReadAllText(_saveFilePath);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            _unitDataList = data.UnitDataList;

            return;
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

        // Copying and pasting items from default list
        _unitDataList = new List<UnitData>(_defaultUnitDataList);

        SaveData saveData = new SaveData();
        saveData.CompanyRankPosition = DEFAULT_COMPANY_RANK_POSITION;
        saveData.DayCount = DEFAULT_DAY_COUNT;
        saveData.MoneyAmount = DEFAULT_MONEY_AMOUNT;
        saveData.UnitDataList = _unitDataList;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText( _saveFilePath, json);

        print("New Game Started");
    }

    public List<UnitData> GetUnitDataList() => _unitDataList;

    public UnitSO GetUnitSO(string name)
    {
        UnitSO unitSO = Resources.Load<UnitSO>($"{UNITS_PATH}/{name}");

        return unitSO;
    }

    public bool SaveExists() => File.Exists(_saveFilePath);
}
