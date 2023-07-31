using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public static event EventHandler OnHowToPlayButtonClicked;

    [SerializeField] private MainMenuPopUpUI _mainMenuPopUpConfirmationUI;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _ngButton;
    [SerializeField] private Button _howToPlayButton;
    [SerializeField] private Button _desktopButton;

    private void Awake()
    {
        _continueButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.ManagingScene);
        });

        _ngButton.onClick.AddListener(() =>
        {
            _mainMenuPopUpConfirmationUI.Initialize("Are you sure you want to start a new game?", () =>
            {
                SaveGameManager.Instance.NewGame();
                Loader.Load(Loader.Scene.ManagingScene);
            }); 
        });

        _howToPlayButton.onClick.AddListener(() =>
        {
            OnHowToPlayButtonClicked?.Invoke(this, EventArgs.Empty);
        });

        _desktopButton.onClick.AddListener(() =>
        {
            _mainMenuPopUpConfirmationUI.Initialize("Are you sure you want to leave the game?", () =>
            {
                Application.Quit();
            });
        });
    }

    private void Start()
    {
        if (!SaveGameManager.Instance.SaveExists())
            _continueButton.gameObject.SetActive(false);
    }
}
