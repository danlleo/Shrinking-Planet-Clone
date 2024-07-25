using UnityEngine;

namespace Utils
{
    public static class ComponentUtils
    {
        public static bool TryGetComponentInChildren<T>(GameObject parentGameObject, out T desiredComponent,
            bool includeInactive = false) where T : Component
        {
            int childCount = parentGameObject.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                GameObject childGameObject = parentGameObject.transform.GetChild(i).gameObject;

                if (!includeInactive && !childGameObject.activeSelf)
                    continue;

                if (!childGameObject.TryGetComponent(out T childComponent)) continue;

                desiredComponent = childComponent;
                return true;
            }

            desiredComponent = null;
            return false;
        }
    }
}
