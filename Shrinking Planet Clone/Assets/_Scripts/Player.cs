using UnityEngine;

public class Player : Subject
{
    private void Start()
    {
        NotifyObservers();
    }
}
