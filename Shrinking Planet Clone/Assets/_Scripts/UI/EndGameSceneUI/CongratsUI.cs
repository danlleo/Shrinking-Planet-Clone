using UnityEngine;
using UnityEngine.UI;

public class CongratsUI : MonoBehaviour
{
    [SerializeField] private Button _proceedButton;

    private void Awake()
    {
        _proceedButton.onClick.AddListener(() =>
        {
            SaveGameManager.Instance.DeleteSave();
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }
}
