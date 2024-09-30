using DG.Tweening;
using UnityEngine;

[DisallowMultipleComponent]
public class DisplayUIObjectAtWorldPosition : MonoBehaviour
{
    [Header("External References")]
    [SerializeField] private Transform _followObject;
    
    [Header("Settings")]
    [SerializeField] private Vector2 _offset;

    [Header("Bounce Settings")] 
    [SerializeField] private bool _shouldBounce = true;
    [SerializeField] private float _bounceHeight = 20f;
    [SerializeField] private float _bounceDuration = 0.85f; 
    
    private void Awake()
    {
        KeepAtWorldPosition();
        BounceLoop();
    }

    private void KeepAtWorldPosition()
    {
        transform.position =
            RectTransformUtility.WorldToScreenPoint(Camera.main, _followObject.transform.TransformPoint(Vector3.zero)) +
            _offset;
    }

    private void BounceLoop()
    {
        if (_shouldBounce) return;
        transform.DOLocalMoveY(transform.localPosition.y + _bounceHeight, _bounceDuration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }
}
