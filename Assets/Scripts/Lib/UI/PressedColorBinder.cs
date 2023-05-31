using Unity.Theme.Binders;
using UnityEngine;
using UnityEngine.UI;

namespace Lib.UI
{
    [ExecuteAlways, ExecuteInEditMode]
    public class PressedColorBinder : BaseColorBinder
    {
        [SerializeField] private Selectable selectable;
        
        protected override void OnEnable()
        {
            if (selectable == null) selectable = GetComponent<Selectable>();
            base.OnEnable();
        }

        protected override void SetColor(Color color)
        {
            var colors = selectable.colors;
            colors.pressedColor = color;
            selectable.colors = colors;
        }
    }
}