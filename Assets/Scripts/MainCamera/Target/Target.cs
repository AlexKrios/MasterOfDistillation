using Assets.Scripts.MainCamera.Disable;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.MainCamera.Target
{
    public class Target : ITarget
    {
        private readonly Camera _mainCamera;

        private readonly IDisable _disable;

        public Vector3 Position { get; set; }

        public Target([Inject(Id = "MainCamera")] Transform mainCamera, IDisable disable)
        {
            _mainCamera = mainCamera.GetComponent<Camera>();

            _disable = disable;
        }

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            Position = _mainCamera.transform.parent.position;
        }

        public void SetTargetPos()
        {
            if (_disable.Find(DisableType.Camera))
            {
                return;
            }

            Position = _mainCamera.transform.parent.position;
        }
    }
}
