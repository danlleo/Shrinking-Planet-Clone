using UnityEngine;
using UnityEngine.UI;
using static InteractSystem;

public class IconFollowCursorUI : MonoBehaviour
{
    [SerializeField] private GameObject _iconFollowCursorUI;
    [SerializeField] private Image _icon;

    private void Start()
    {
        HideUI();

        InteractSystem.Instance.OnObjectPickUp += InteractSystem_OnObjectPickUp;
        InteractSystem.Instance.OnObjectDrop += InteractSystem_OnObjectDrop;
    }

    private void OnDestroy()
    {
        InteractSystem.Instance.OnObjectPickUp -= InteractSystem_OnObjectPickUp;
        InteractSystem.Instance.OnObjectDrop -= InteractSystem_OnObjectDrop;
    }

    private void Update()
    {
        if (!_iconFollowCursorUI.activeSelf)
            return;

        PlaceIconToMousePosition();
    }

    private void PlaceIconToMousePosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        _icon.transform.position = mouseScreenPosition;
    }

    private void InteractSystem_OnObjectDrop(object sender, System.EventArgs e)
    {
        HideUI();
    }

    private void InteractSystem_OnObjectPickUp(object sender, ObjectPickUpArgs e)
    {
        ShowUI();

        SetIconSprite(e.ObjectSprite);
    }

    private void ShowUI() => _iconFollowCursorUI.SetActive(true);

    private void HideUI() => _iconFollowCursorUI.SetActive(false);

    private void SetIconSprite(Sprite sprite) => _icon.sprite = sprite;
}
