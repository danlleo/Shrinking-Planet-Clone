using System;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public static event EventHandler OnMeteorExplode;

    private float _moveSpeed = 5f;

    private Vector3 _planetPoint;

    public void Setup(Vector3 planetPoint)
    {
        _planetPoint = planetPoint;
    }

    public void Update()
    {
        TravelToPlanetPoint();
    }

    public void TravelToPlanetPoint()
    {
        if (Vector3.Distance(transform.position, _planetPoint) > .1f)
        {
            Vector3 moveDirection = _planetPoint - transform.position;

            transform.position += moveDirection * _moveSpeed * Time.deltaTime;
        }
        else
        {
            Explode();
        }
    }

    private void Explode()
    {
        OnMeteorExplode?.Invoke(this, EventArgs.Empty);
        Destroy(gameObject);
    }
}
