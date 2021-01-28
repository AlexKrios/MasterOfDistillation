using UnityEngine;

namespace Scripts.Scenes.Village.MainCamera
{
    public class Target : MonoBehaviour, ITarget
    {
        private IDisable Disable { get => RoomManager.Instance.disable; }
        private Camera _mainCamera { get => RoomManager.Instance.mainCamera; }

        private Vector3 _position;
        public Vector3 Position 
        {
            get { return _position; }
            set { _position = value; }
        }

        private void Start()
        {
            _position = _mainCamera.transform.parent.position;
        }

        public void SetTargetPos()
        {
            if (Disable.Find("BuildSelect"))
            {
                return;
            }

            _position = _mainCamera.transform.parent.position;
        }
    }
}
