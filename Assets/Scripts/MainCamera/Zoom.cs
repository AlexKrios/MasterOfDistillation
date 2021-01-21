using UnityEngine;

namespace Scripts.MainCamera
{
    public class Zoom : MonoBehaviour
    {
        private GameManager GameManager { get => GameManager.Instance; }
        private Camera _mainCamera { get => GameManager.mainCamera; }
        private float _zoomSpeed { get => GameManager.zoomSpeed; }

        private float targetZoom;

        private void Start()
        {
            targetZoom = _mainCamera.orthographicSize;
        }

        private void DesktopZoom()
        {
            var scrollData = Input.GetAxis("Mouse ScrollWheel");

            targetZoom -= scrollData * _zoomSpeed;
            targetZoom = Mathf.Clamp(targetZoom, 5f, 20f);
        }

        private void MobileZoom()
        {
            if (Input.touchCount == 2)
            {
                var firstTouch = Input.GetTouch(0);
                var secondTouch = Input.GetTouch(1);

                var firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
                var secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

                var touchesPrevPosDiff = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
                var touchesCurPosDiff = (firstTouch.position - secondTouch.position).magnitude;

                var zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * (_zoomSpeed / 100f);

                if (touchesPrevPosDiff > touchesCurPosDiff)
                {
                    _mainCamera.orthographicSize += zoomModifier;
                }
                if (touchesPrevPosDiff < touchesCurPosDiff)
                {
                    _mainCamera.orthographicSize -= zoomModifier;
                }

                targetZoom = Mathf.Clamp(_mainCamera.orthographicSize, 5f, 20f);
            }
        }

        private void Update()
        {
            DesktopZoom();
            MobileZoom();

            _mainCamera.orthographicSize = Mathf.Lerp(
                _mainCamera.orthographicSize,
                targetZoom,
                Time.deltaTime * 10
            );
        }
    }
}