using UnityEngine;

namespace Scripts.Scenes.Village.MainCamera
{
    public class Rotate : MonoBehaviour
    {
        private GameManager GameManager { get => GameManager.Instance; }
        private Transform _mainCamera { get => RoomManager.Instance.mainCamera.transform.parent; }
        private float _rotateSpeed { get => GameManager.rotateSpeed; }

        private void Start() { }

        private void RotateDesktop()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                _mainCamera.transform.RotateAround(transform.position, -Vector3.up, _rotateSpeed / 2);
            }
            if (Input.GetKey(KeyCode.E))
            {
                _mainCamera.transform.RotateAround(transform.position, Vector3.up, _rotateSpeed / 2);
            }
        }

        private void RotateMobile()
        {
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Touch touch = Input.GetTouch(0);

                _mainCamera.transform.Rotate(0f, touch.deltaPosition.x * _rotateSpeed * 5 * Time.deltaTime, 0f);
            }
        }

        private void Update()
        {
            RotateDesktop();
            RotateMobile();
        }
    }
}