using UnityEngine;
using Zenject;

namespace Scripts.Scenes.Main.MainCamera
{
    public class Target : ITarget
    {
        private Camera _mainCamera;

        private IDisable _disable;

        private Vector3 _position;
        public Vector3 Position 
        {
            get { return _position; }
            set { _position = value; }
        }

        public Target([Inject(Id = "MainCamera")] Transform mainCamera, IDisable disable, [Inject(Id = "MainCanvas")] RectTransform mainCanvas)
        {
            _mainCamera = mainCamera.GetComponent<Camera>();

            _disable = disable;
        }

        private void Start()
        {
            _position = _mainCamera.transform.parent.position;
        }

        public void SetTargetPos()
        {
            if (_disable.Find("WorkshopSelect"))
            {
                return;
            }

            _position = _mainCamera.transform.parent.position;
        }
    }
}
