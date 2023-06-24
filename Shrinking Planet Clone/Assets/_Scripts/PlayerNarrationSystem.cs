using UnityEngine;

public class PlayerNarrationSystem : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _playerSubject;

    public void OnNotify()
    {
        print("PNS: NOTIFIED");
    }

    private void OnEnable()
    {
        _playerSubject.AddObserver(this);
    }

    private void OnDisable()
    {
        _playerSubject.RemoveObserver(this);
    }
}
