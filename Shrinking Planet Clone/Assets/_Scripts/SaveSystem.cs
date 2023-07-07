using UnityEngine;

public class SaveSystem : Singleton<SaveSystem>
{
    private string _saveFilePath;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _saveFilePath = Application.persistentDataPath + "/save.json";
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData();

    }

    public void LoadGame()
    {

    }
}
