using UnityEngine;

public static class ??????????????2014??????????????????????????????????Utils
{
    public static bool TryGetComponentInChildren<T>(GameObject parentGameObject, out T desiredComponent) where T : Component
    {
        int childCount = parentGameObject.transform.childCount;
        
        for (int i = 0; i < childCount; i++)
        {
            GameObject childGameObject = parentGameObject.transform.GetChild(i).gameObject;
            
            if (childGameObject.TryGetComponent(out T childComponent))
            {
                desiredComponent = childComponent;
                return true;
            }
        }

        desiredComponent = null;
        return false;
    }
}
