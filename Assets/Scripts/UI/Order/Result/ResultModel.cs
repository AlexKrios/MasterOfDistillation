using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using Zenject;

#pragma warning disable 649

namespace Assets.Scripts.Ui.Order.Result
{
    [UsedImplicitly]
    public class ResultModel : MonoBehaviour
    {
        [Inject] private readonly ResultCanvasFactory.Settings _resultCanvasSettings;

        private Transform _transform;
        private Rigidbody _rigidbody;

        // ReSharper disable once UnusedMember.Local
        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
            _rigidbody = GetComponent<Rigidbody>();

            StartCoroutine(StartTransformation());
        }

        public void SetInitTransform(Transform parent)
        {
            _transform.SetParent(parent);
            _transform.localPosition = new Vector3(0, 0, -500);
            _transform.localRotation = Quaternion.Euler(-45, 0, 0);
        }

        private IEnumerator StartTransformation()
        {
            var startScale = _transform.localScale;
            var targetScale = new Vector3(250, 250, 250);

            var fadeTime = _resultCanvasSettings.FadeTime;

            _rigidbody.AddTorque(Vector3.down * 10000);

            var elapsedTime = 0f;
            while (elapsedTime < fadeTime)
            {
                elapsedTime += Time.deltaTime;
                _transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / fadeTime);

                yield return new WaitForEndOfFrame();
            }
        }

        // ReSharper disable once UnusedMember.Local
        private void FixedUpdate()
        {
            var turn = -Input.GetAxis("Horizontal");
            _rigidbody.AddTorque(_transform.up * 100 * turn);

            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                var touch = Input.GetTouch(0);
                var x = touch.deltaPosition.x * 10;

                _rigidbody.AddTorque(Vector3.down * x);
            }
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<GameObject, ResultModel> { }
    }
}
