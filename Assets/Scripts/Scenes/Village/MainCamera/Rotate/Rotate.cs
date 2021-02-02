using Scripts.Scenes.Village.Buildings.MainCamera;
using UnityEngine;
using Zenject;

namespace Scripts.Scenes.Village.MainCamera
{
    public class Rotate : MonoBehaviour
    {
        private Transform _mainCamera;

        private float _rotateSpeed;

        [Inject]
        public void Construct(GameManager gameManager, ICameraController cameraController)
        {            
            _mainCamera = cameraController.MainCamera.transform.parent;
            _rotateSpeed = gameManager.rotateSpeed;
        }

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