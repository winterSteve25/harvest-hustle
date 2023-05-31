using DG.Tweening;
using UnityEngine;

namespace Game.Managers
{
    public class NavigationManager : MonoBehaviour
    {
        [SerializeField] private CanvasGroup currentlyShowing;
        [SerializeField] private CanvasGroup[] tabs;

        private void Start()
        {
            for (var index = 1; index < tabs.Length; index++)
            {
                var tab = tabs[index];
                tab.alpha = 0;
                tab.interactable = false;
                tab.blocksRaycasts = false;
            }
        }

        public void SwitchTo(CanvasGroup content)
        {
            if (currentlyShowing == content) return;
            currentlyShowing.DOFade(0, 0.2f);
            currentlyShowing.interactable = false;
            currentlyShowing.blocksRaycasts = false;
            
            content.DOFade(1, 0.2f);
            currentlyShowing = content;
            currentlyShowing.interactable = true;
            currentlyShowing.blocksRaycasts = true;
        }
    }
}