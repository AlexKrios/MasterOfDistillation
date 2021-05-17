using UnityEngine;
using Zenject;

namespace Assets.Scripts.Scenes.Main.MainCamera.Rotate
{
    public class Rotate : MonoBehaviour
    {
        private Transform _mainCamera;

        private float _rotateSpeed;

        [Inject]
        public void Construct(GameManager gameManager, [Inject(Id = "MainCamera")] Transform mainCamera)
        {            
            _mainCamera = mainCamera.parent;
            _rotateSpeed = gameManager.RotateSpeed;
        }

        // ReSharper disable once UnusedMember.Local
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
                var touch = Input.GetTouch(0);

                _mainCamera.transform.Rotate(0f, touch.deltaPosition.x * _rotateSpeed * 5 * Time.deltaTime, 0f);
            }
        }

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            RotateDesktop();
            RotateMobile();
        }
    }
}