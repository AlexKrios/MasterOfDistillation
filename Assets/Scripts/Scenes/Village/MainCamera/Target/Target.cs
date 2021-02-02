using Scripts.Scenes.Village.Buildings.MainCamera;
using UnityEngine;

namespace Scripts.Scenes.Village.MainCamera
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

        public Target(ICameraController cameraController, IDisable disable)
        {
            _mainCamera = cameraController.MainCamera;

            _disable = disable;
        }

        private void Start()
        {
            _position = _mainCamera.transform.parent.position;
        }

        public void SetTargetPos()
        {
            if (_disable.Find("BuildingSelect"))
            {
                return;
            }

            _position = _mainCamera.transform.parent.position;
        }
    }
}
