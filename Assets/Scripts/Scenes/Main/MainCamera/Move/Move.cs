using UnityEngine;
using Zenject;

namespace Scripts.Scenes.Main.MainCamera
{
    public class Move : MonoBehaviour
    {
        private Transform _mainCamera;

        private ITarget _target;
        private IDisable _disable;

        private float _moveSpeed;

        [Inject]
        public void Construct(GameManager gameManager, [Inject(Id = "MainCamera")] Transform mainCamera, ITarget target, IDisable disable)
        {
            _mainCamera = mainCamera.parent;

            _target = target;
            _disable = disable;

            _moveSpeed = gameManager.moveSpeed;
        }

        private void Start() { }

        private void DesktopMovement()
        {
            if (!_disable.IsEmpty())
            {
                return;
            }

            if (Input.GetKey(KeyCode.W))
            {
                _mainCamera.transform.Translate(transform.forward * _moveSpeed / 10, Space.Self);
            }
            if (Input.GetKey(KeyCode.S))
            {
                _mainCamera.transform.Translate(-transform.forward * _moveSpeed / 10, Space.Self);
            }
            if (Input.GetKey(KeyCode.D))
            {
                _mainCamera.transform.Translate(transform.right * _moveSpeed / 10, Space.Self);
            }
            if (Input.GetKey(KeyCode.A))
            {
                _mainCamera.transform.Translate(-transform.right * _moveSpeed / 10, Space.Self);
            }
        }        

        private void MobileMovement()
        {
            if (!_disable.IsEmpty())
            {
                return;
            }

            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                var touch = Input.GetTouch(0);
                var x = -touch.deltaPosition.x * 0.02f * _moveSpeed;
                var y = 0;
                var z = -touch.deltaPosition.y * 0.02f * _moveSpeed;

                _mainCamera.transform.Translate(x, y, z, Space.Self);
            }
        }

        private void ClampMove()
        {
            var x = Mathf.Clamp(_mainCamera.transform.position.x, -50f, 50f);
            var y = _mainCamera.transform.position.y;
            var z = Mathf.Clamp(_mainCamera.transform.position.z, -50f, 50f);

            _mainCamera.transform.position = new Vector3(x, y, z);
        }

        private void Update()
        {
            DesktopMovement();
            MobileMovement();

            _target.SetTargetPos();
            _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, _target.Position, 0.05f);

            ClampMove();
        }
    }
}