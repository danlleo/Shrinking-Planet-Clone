using UnityEngine;

public class SaveSystem : Singleton<SaveSystem>
{
    private IDataService _dataService = new JsonDataService();

    private SaveData saveData = new("danlleo", 22);

    private bool _encryptionEnabled;

    protected override void Awake()
    {
        base.Awake();
    }

    // For testing purposes
    public void Update()
    {
        if (InputManager.Instance.IsTButtonDownThisFrame())
        {
            SerializeJson();
        }
    }

    public void SerializeJson()
    {
        if (_dataService.SaveData("game-save.json", saveData, _encryptionEnabled))
        {
            Debug.Log("Saved");
        }
        else
        {
            Debug.LogError("Could not save file!");
        }
    }
}
