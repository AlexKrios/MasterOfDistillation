using UnityEngine;

namespace Scripts.MainCamera
{
    public class Rotate : MonoBehaviour
    {
        private GameManager GameManager { get => GameManager.Instance; }
        private float _rotateSpeed { get => GameManager.rotateSpeed; }

        private Transform _lookPoint;

        private void Start()
        {
            _lookPoint = GameObject.Find("LookPoint").GetComponent<Transform>();
        }

        private void RotateDesktop()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                transform.RotateAround(_lookPoint.position, -Vector3.up, _rotateSpeed / 2);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.RotateAround(_lookPoint.position, Vector3.up, _rotateSpeed / 2);
            }
        }

        private void RotateMobile()
        {
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Touch touch = Input.GetTouch(0);

                transform.Rotate(0f, touch.deltaPosition.x * _rotateSpeed * 5 * Time.deltaTime, 0f);
            }
        }

        private void Update()
        {
            RotateDesktop();
            RotateMobile();
        }
    }
}