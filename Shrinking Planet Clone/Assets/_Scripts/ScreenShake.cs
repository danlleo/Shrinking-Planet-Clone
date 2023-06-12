using System.Collections;
using UnityEngine;

public class ScreenShake : Singleton<ScreenShake>
{
    [SerializeField] private float _shakeMagnitude;
    [SerializeField] private float _shakeDuration;

    private Camera _camera;

    protected override void Awake()
    {
        base.Awake();

        _camera = Camera.main;
    }

    private void Start()
    {
        Meteor.OnMeteorExplode += Meteor_OnMeteorSpawn;
    }

    private void Meteor_OnMeteorSpawn(object sender, System.EventArgs e)
    {
        //StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float elapsedTime = 0f;

        Vector3 initialPosition = _camera.transform.localPosition;

        while (elapsedTime < _shakeDuration)
        {
            Vector3 randomPoint = Random.insideUnitSphere * _shakeMagnitude;

            _camera.transform.localPosition = new Vector3(_camera.transform.localPosition.x + randomPoint.x, _camera.transform.localPosition.y + randomPoint.y, _camera.transform.localPosition.z);

            yield return null;

            elapsedTime += Time.deltaTime;
        }

        _camera.transform.localPosition = initialPosition;
    }
}
