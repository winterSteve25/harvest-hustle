using DG.Tweening;
using Unity.Theme.Binders;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Lib.UI
{
    [ExecuteAlways, ExecuteInEditMode]
    public class InteractableAnimator : BaseColorBinder, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image image;
        [SerializeField] private bool noBackgroundDefault;
        
        private Color _normalColor;
        private Color _hoveredColor;
        private bool _isHovering;
        
        private void Start()
        {
            if (noBackgroundDefault && _normalColor.a != 0)
            {
                _hoveredColor = _normalColor;
                _normalColor.a = 0;
            }
            else
            {
                _hoveredColor = _normalColor;
                _hoveredColor.a += 0.3f;
            }
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            image.DOColor(_hoveredColor, 0.2f);
            _isHovering = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            image.DOColor(_normalColor, 0.2f);
            _isHovering = false;
        }

        protected override void SetColor(Color color)
        {
            if (noBackgroundDefault)
            {
                _normalColor.a = 0;
                _hoveredColor = color;
            }
            else
            {
                _normalColor = color;
                _hoveredColor = _normalColor;
                _hoveredColor.a += 0.3f;
            }
            
            if (Application.isPlaying)
            {
                image.DOColor(_isHovering ? _hoveredColor : _normalColor, 0.2f);
            }
            else
            {
                image.color = _isHovering ? _hoveredColor : _normalColor;
            }
        }
    }
}