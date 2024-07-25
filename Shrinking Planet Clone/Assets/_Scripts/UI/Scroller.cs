using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Scroller : MonoBehaviour
    {
        [SerializeField] private RawImage _imageToScroll;
        [SerializeField] private float _x;
        [SerializeField] private float _y;

        private void Update()
        {
            _imageToScroll.uvRect = new Rect(_imageToScroll.uvRect.position + new Vector2(_x, _y) * Time.deltaTime,
                _imageToScroll.uvRect.size);
        }
    }
}
