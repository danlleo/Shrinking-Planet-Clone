using System;
using UnityEngine;

public class WaterDrinker : MonoBehaviour, IInteractable, ISelectable
{
    private const int DEFAULT_LAYER = 0;
    private const int OUTLINE_LAYER = 31;

    public event EventHandler OnWaterDrinkerInteract;

    [SerializeField] private GameObject[] _waterDrinkerVisuals;

    public void Interact()
    {
        OnWaterDrinkerInteract?.Invoke(this, EventArgs.Empty);
    }

    public void OnMouseEnter()
    {
        SoundManager.Instance.PlayUnitMouseHover();

        foreach (GameObject gameObject in _waterDrinkerVisuals)
        {
            ChangeLayerInObject(gameObject, OUTLINE_LAYER);
        }
    }

    public void OnMouseExit()
    {
        foreach (GameObject gameObject in _waterDrinkerVisuals)
        {
            ChangeLayerInObject(gameObject, DEFAULT_LAYER);
        }
    }

    public void ChangeLayerInObject(GameObject targetObject, int newLayer)
    {
        targetObject.layer = newLayer;
    }
}
