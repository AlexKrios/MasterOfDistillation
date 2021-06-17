using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using Zenject;

// ReSharper disable UnusedMember.Local

#pragma warning disable 649

namespace Assets.Scripts.Ui.Popup.Notification
{
    [UsedImplicitly]
    public class PopupNotificationBase : PopupBase
    {
        [Inject] private readonly IPopupController _popupController;

        private RectTransform _transform;
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();

            var component = GetComponent<PopupNotification>();

            Text = component.Text;
        }

        private void Start()
        {
            _canvasGroup.alpha = 0;

            StartCoroutine(Animation());
        }

        private IEnumerator Animation()
        {
            var startPosition = _transform.localPosition;
            var targetPosition = new Vector3(startPosition.x, startPosition.y - 10, startPosition.z);

            var elapsedTime = 0f;
            while (elapsedTime < FadeTime)
            {
                elapsedTime += Time.deltaTime;
                _transform.localPosition = Vector3.Slerp(startPosition, targetPosition, elapsedTime / FadeTime);
                _canvasGroup.alpha = Mathf.Lerp(0, 1, elapsedTime / FadeTime);

                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(3);

            elapsedTime = 0f;
            while (elapsedTime < FadeTime)
            {
                elapsedTime += Time.deltaTime;
                _transform.localPosition = Vector3.Slerp(targetPosition, startPosition, elapsedTime / FadeTime);
                _canvasGroup.alpha = Mathf.Lerp(1, 0, elapsedTime / FadeTime);

                yield return new WaitForEndOfFrame();
            }

            _popupController.Remove(gameObject);
        }
    }
}
