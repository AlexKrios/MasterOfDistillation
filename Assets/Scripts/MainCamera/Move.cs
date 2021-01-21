using UnityEngine;

namespace Scripts.MainCamera
{
    public class Move : MonoBehaviour
    {
        private GameManager GameManager { get => GameManager.Instance; }
        private float _moveSpeed { get => GameManager.moveSpeed; }

        private void DesktopMovement()
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(transform.forward * _moveSpeed / 10, Space.World);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-transform.forward * _moveSpeed / 10, Space.World);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(transform.right * _moveSpeed / 10, Space.World);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-transform.right * _moveSpeed / 10, Space.World);
            }
        }

        private void MobileMovement()
        {
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                var touch = Input.GetTouch(0);
                transform.Translate(
                    -touch.deltaPosition.x * _moveSpeed * Time.deltaTime * 3,
                    0,
                    -touch.deltaPosition.y * _moveSpeed * Time.deltaTime * 3,
                    Space.Self
                );
            }
        }

        private void Update()
        {
            DesktopMovement();
            MobileMovement();

            transform.localPosition = new Vector3(
                Mathf.Clamp(transform.position.x, -50f, 50f),
                20,
                Mathf.Clamp(transform.position.z, -50f, 30f)
            );
        }
    }
}