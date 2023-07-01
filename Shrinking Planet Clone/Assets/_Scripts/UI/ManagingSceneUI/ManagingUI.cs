using UnityEngine;
using UnityEngine.UI;

public class ManagingUI : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    private void Awake()
    {
        _startButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.WorkingScene);
        });
    }
}
