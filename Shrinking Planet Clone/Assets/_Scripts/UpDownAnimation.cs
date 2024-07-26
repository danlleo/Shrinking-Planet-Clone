using DG.Tweening;
using UnityEngine;

[DisallowMultipleComponent]
public class UpDownAnimation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _moveDistance = 1f;
    [SerializeField] private float _moveDuration = 1f;
    
    private void Start()
    {
        Animate();
    }

    private void Animate()
    {
        transform.DOMoveY(transform.position.y + _moveDistance, _moveDuration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine); 
    }
}
