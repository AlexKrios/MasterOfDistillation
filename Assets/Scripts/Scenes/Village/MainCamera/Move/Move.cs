using UnityEngine;

namespace Scripts.Scenes.Village.MainCamera
{
    public class Move : MonoBehaviour
    {
        private ITarget Target { get => RoomManager.Instance.target; }
        private IDisable Disable { get => RoomManager.Instance.disable; }
        private Transform _mainCamera { get => RoomManager.Instance.mainCamera.transform.parent; }
        private float _moveSpeed { get => GameManager.Instance.moveSpeed; }
        private Vector3 _targetPos { get => Target.Position; }

        private void Start() { }

        private void DesktopMovement()
        {
            if (!Disable.IsEmpty())
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
            if (!Disable.IsEmpty())
            {
                return;
            }

            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                var touch = Input.GetTouch(0);
                var x = -touch.deltaPosition.x * 0.05f * _moveSpeed;
                var y = 0;
                var z = -touch.deltaPosition.y * 0.05f * _moveSpeed;

                _mainCamera.transform.Translate(x, y, z, Space.Self);
            }
        }

        private void ClampMove()
        {
            var x = Mathf.Clamp(_mainCamera.transform.position.x, -50f, 50f);
            var y = 0;
            var z = Mathf.Clamp(_mainCamera.transform.position.z, -50f, 50f);

            _mainCamera.transform.position = new Vector3(x, y, z);
        }

        private void Update()
        {
            DesktopMovement();
            MobileMovement();

            Target.SetTargetPos();
            _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, _targetPos, 0.05f);

            ClampMove();
        }
    }
}