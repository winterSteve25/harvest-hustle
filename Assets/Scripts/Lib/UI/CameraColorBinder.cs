using Sirenix.OdinInspector;
using Unity.Theme.Binders;
using UnityEngine;

namespace Lib.UI
{
    [AddComponentMenu("Theme/Camera Color Binder")]
    [ExecuteAlways, ExecuteInEditMode]
    public class CameraColorBinder : BaseColorBinder
    {
        [SerializeField, Required] private Camera cam;

        protected override void OnEnable()
        {
            if (cam == null) cam = GetComponent<Camera>();
        }

        protected override void SetColor(Color color)
        {
            cam.backgroundColor = color;
        }
    }
}