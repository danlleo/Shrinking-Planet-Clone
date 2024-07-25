using System;
using Managers;
using UnityEngine;

namespace InteractableObjects
{
    public class WaterDrinker : MonoBehaviour, IInteractable, ISelectable
    {
        private const int DefaultLayer = 0;
        private const int OutlineLayer = 31;
        public event EventHandler OnWaterDrinkerInteract;

        [SerializeField] private GameObject[] _waterDrinkerVisuals;

        public void Interact()
        {
            OnWaterDrinkerInteract?.Invoke(this, EventArgs.Empty);
        }

        public void OnMouseEnter()
        {
            SoundManager.Instance.PlayUnitMouseHover();

            foreach (GameObject waterDrinkerVisualGameObject in _waterDrinkerVisuals)
            {
                ChangeLayerInObject(waterDrinkerVisualGameObject, OutlineLayer);
            }
        }

        public void OnMouseExit()
        {
            foreach (GameObject waterDrinkerVisualGameObject in _waterDrinkerVisuals)
            {
                ChangeLayerInObject(waterDrinkerVisualGameObject, DefaultLayer);
            }
        }

        public void ChangeLayerInObject(GameObject targetObject, int newLayer)
        {
            targetObject.layer = newLayer;
        }
    }
}
