using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one singleton");
            Destroy(gameObject);
            return;
        }

        Instance = this as T;
    }
}
