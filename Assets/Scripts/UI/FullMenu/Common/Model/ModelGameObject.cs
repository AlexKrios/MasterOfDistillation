using JetBrains.Annotations;
using UnityEngine;
using Zenject;
// ReSharper disable UnusedMember.Local

#pragma warning disable 649

namespace Assets.Scripts.Ui.FullMenu.Common.Model
{
    [UsedImplicitly]
    public class ModelGameObject : MonoBehaviour
    {
        private Transform _transform;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
            _rigidbody = GetComponent<Rigidbody>();

            SetInitTransform();
        }

        private void SetInitTransform()
        {
            _transform.localPosition = new Vector3(0, 0, 0);
            _transform.localRotation = Quaternion.Euler(45, 0, 45);
            _transform.localScale = new Vector3(250, 250, 250);
        }

        private void FixedUpdate()
        {
            var turn = Input.GetAxis("Horizontal");
            _rigidbody.AddTorque(Vector3.up * 100 * turn);

            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                var touch = Input.GetTouch(0);
                var x = touch.deltaPosition.x * 10;

                _rigidbody.AddTorque(Vector3.down * x);
            }
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<GameObject, ModelGameObject> { }
    }
}
