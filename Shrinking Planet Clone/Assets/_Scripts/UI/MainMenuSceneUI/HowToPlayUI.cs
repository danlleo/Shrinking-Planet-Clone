using UnityEngine;
using UnityEngine.UI;

public class HowToPlayUI : MonoBehaviour
{
    [SerializeField] private GameObject _howToPlayUI;
    [SerializeField] private Button _closeButton;

    private void Awake()
    {
        HideUI();

        _closeButton.onClick.AddListener(() =>
        {
            HideUI();
        });
    }

    private void Start()
    {
        MainMenuUI.OnHowToPlayButtonClicked += MainMenuUI_OnHowToPlayButtonClicked;
    }

    private void OnDestroy()
    {
        MainMenuUI.OnHowToPlayButtonClicked -= MainMenuUI_OnHowToPlayButtonClicked;
    }

    private void MainMenuUI_OnHowToPlayButtonClicked(object sender, System.EventArgs e)
    {
        ShowUI();
    }

    private void ShowUI() => _howToPlayUI.SetActive(true);

    private void HideUI() => _howToPlayUI.SetActive(false);
}
