using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private GameObject _gamePauseUI;
    [SerializeField] private GamePausePopUpConfirmationUI _gamePausePopUpConfirmationUI;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _managementButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _desktopButton;

    private void Awake()
    {
        HideUI();

        _continueButton.onClick.AddListener(() =>
        {
            GameManager.Instance.Resume();
        });

        _managementButton.onClick.AddListener(() =>
        {
            _gamePausePopUpConfirmationUI.Initialize("Are you sure you want to go to the Management Menu?", () => 
            {
                Loader.Load(Loader.Scene.ManagingScene);
            });
        });

        _mainMenuButton.onClick.AddListener(() =>
        {
            _gamePausePopUpConfirmationUI.Initialize("Are you sure you want to go to the Main Menu?", () =>
            {
                Loader.Load(Loader.Scene.MainMenuScene);
            });
        });

        _desktopButton.onClick.AddListener(() =>
        {
            _gamePausePopUpConfirmationUI.Initialize("Are you sure you want to go to the Desktop?", () =>
            {
                Application.Quit();
            });
        });
    }

    private void Start()
    {
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGamePaused -= GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnpaused -= GameManager_OnGameUnpaused;
    }

    private void GameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        HideUI();
    }

    private void GameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        ShowUI();
    }

    private void ShowUI() => _gamePauseUI.SetActive(true);

    private void HideUI() => _gamePauseUI.SetActive(false);
}
