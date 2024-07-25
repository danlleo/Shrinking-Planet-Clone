using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unit;
using UnityEngine;

namespace Managers
{
    public class SaveGameManager : Singleton<SaveGameManager>
    {
        [SerializeField] private List<UnitData> _defaultUnitDataList = new();
    
        private List<UnitData> _unitDataList = new();
        private List<PurchasableItem> _purchasedItemsList;

        private SaveData _saveData;

        private string _saveFilePath;

        private const string UnitsPath = "Units";

        private const int DefaultCompanyRankPosition = 100;
        private const int DefaultDayCount = 1;
        private const int DefaultMoneyAmount = 100;

        protected override void Awake()
        {
            base.Awake();

            _saveFilePath = Application.persistentDataPath + "/save.json";
        
            if (SaveExists())
                LoadGame();    
        }

        public void SaveGame(int companyRankPosition, int dayCount, int moneyAmount)
        {
            SaveData saveData = new SaveData();
            saveData.CompanyRankPosition = companyRankPosition;
            saveData.DayCount = dayCount;
            saveData.MoneyAmount = moneyAmount;
            saveData.UnitDataList = _unitDataList;
            saveData.PurchasedItems = ItemStashManager.Instance.GetPurchasedItems().ToList();

            string json = JsonUtility.ToJson(saveData);

            File.WriteAllText(_saveFilePath, json);

            print("Game Saved");
        }

        public void LoadGame()
        {
            if (File.Exists(_saveFilePath))
            {
                string json = File.ReadAllText(_saveFilePath);

                SaveData saveData = JsonUtility.FromJson<SaveData>(json);

                _unitDataList = saveData.UnitDataList;
                _purchasedItemsList = saveData.PurchasedItems;
                _saveData = saveData;

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
            _purchasedItemsList = new List<PurchasableItem>();

            SaveData saveData = new SaveData();
            saveData.CompanyRankPosition = DefaultCompanyRankPosition;
            saveData.DayCount = DefaultDayCount;
            saveData.MoneyAmount = DefaultMoneyAmount;
            saveData.UnitDataList = _unitDataList;
            saveData.PurchasedItems = _purchasedItemsList;

            _saveData = saveData;

            string json = JsonUtility.ToJson(saveData);

            File.WriteAllText(_saveFilePath, json);

            print("New Game Started");
        }

        public IEnumerable<UnitData> GetUnitDataList() => _unitDataList;

        public void AddUnit(UnitData unitData) => _unitDataList.Add(unitData);

        public UnitSO GetUnitSO(string name)
        {
            UnitSO unitSO = Resources.Load<UnitSO>($"{UnitsPath}/{name}");

            return unitSO;
        }

        public bool TrySaveUnitLevel(string unitSOName, int level)
        {
            UnitData foundUnitData = _unitDataList.Find(data => data.UnitSOName == unitSOName);

            if (foundUnitData == null)
                return false;

            foundUnitData.UnitLevel = level;

            return true;
        }

        public bool TrySaveUnitLeftOverXPs(string unitSOName, int xp)
        {
            UnitData foundUnitData = _unitDataList.Find(data => data.UnitSOName == unitSOName);

            if (foundUnitData == null)
                return false;

            foundUnitData.UnitLeftOverXPs = xp;

            return true;
        }

        public bool SaveExists() => File.Exists(_saveFilePath);

        public void DeleteSave() => File.Delete(_saveFilePath);

        public int GetDayCount() => _saveData.DayCount;

        public int GetCompanyRankPosition() => _saveData.CompanyRankPosition;

        public int GetMoneyAmount() => _saveData.MoneyAmount;

        public IEnumerable<PurchasableItem> RetrievePurchasedItems() => _saveData.PurchasedItems;
    }
}
