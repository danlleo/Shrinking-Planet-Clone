using System;
using UnityEngine;

public class WaterDrinker : MonoBehaviour, IInteractable
{
    public event EventHandler OnWaterDrinkerInteract;

    public void Interact()
    {
        OnWaterDrinkerInteract?.Invoke(this, EventArgs.Empty);
    }
}
