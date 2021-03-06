﻿using Assets.Scripts.MainCamera.Disable;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.MainCamera.Zoom
{
    public class Zoom : MonoBehaviour
    {
        [Inject] private IDisable _disable;

        private Camera _mainCamera;

        private float _zoomSpeed;

        private float _targetZoom;

        [Inject]
        public void Construct(GameManager gameManager, [Inject(Id = "MainCamera")] Transform mainCamera)
        {
            _mainCamera = mainCamera.GetComponent<Camera>();
            _zoomSpeed = gameManager.ZoomSpeed;
        }

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            _targetZoom = _mainCamera.orthographicSize;
        }

        private void DesktopZoom()
        {
            var scrollData = Input.GetAxis("Mouse ScrollWheel");

            _targetZoom -= scrollData * 5 * _zoomSpeed;
            _targetZoom = Mathf.Clamp(_targetZoom, 5f, 30f);
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

                _targetZoom = Mathf.Clamp(_mainCamera.orthographicSize, 5f, 30f);
            }
        }

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            if (_disable.Find(DisableType.Camera))
            {
                return;
            }

            DesktopZoom();
            MobileZoom();

            _mainCamera.orthographicSize = Mathf.Lerp(_mainCamera.orthographicSize, _targetZoom, Time.deltaTime * 10);
        }
    }
}