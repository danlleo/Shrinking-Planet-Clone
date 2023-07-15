using UnityEngine;

public interface ISelectable
{
    void OnMouseEnter();

    void OnMouseExit();

    void ChangeLayerInObject(GameObject targetObject, int newLayer);
}
