using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSounds : MonoBehaviour, IPointerEnterHandler
{
    public static event EventHandler OnButtonHover;
    public static event EventHandler OnButtonPressed;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(() =>
        {
            OnButtonPressed?.Invoke(this, EventArgs.Empty);
        });
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnButtonHover?.Invoke(this, EventArgs.Empty);
    }
}
