using DG.Tweening;
using Game.Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UI
{
    public class SidebarContentButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image indicatorImage;
        [SerializeField] private CanvasGroup content;
        [SerializeField] private NavigationManager navigationManager;
    
        public void OnPointerClick(PointerEventData eventData)
        {
            indicatorImage.rectTransform.DOMoveY(transform.position.y, 0.2f)
                .SetEase(Ease.OutCubic);
            navigationManager.SwitchTo(content);
        }
    }
}