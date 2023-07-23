using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuyItemUISingle : MonoBehaviour, IPurchasable, IPointerClickHandler
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descriptionText;

    public void Initialize(Sprite sprite, string title, string description)
    {
        _iconImage.sprite = sprite;
        _titleText.text = title;
        _descriptionText.text = description;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Purchase();
    }

    public void Purchase()
    {
        print($"You bought: {_titleText.text}");
    }
}
