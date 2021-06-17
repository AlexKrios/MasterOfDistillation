using Assets.Scripts.Ui.Popup.Notification;
using Assets.Scripts.Ui.Popup.OneButton;
using Assets.Scripts.Ui.Popup.TwoButton;
using JetBrains.Annotations;
using Zenject;

namespace Assets.Scripts.Ui.Popup
{
    [UsedImplicitly]
    public class PopupFactory : IPopupFactory
    {
        [Inject] private readonly PopupNotificationFactory _popupNotificationFactory;
        [Inject] private readonly PopupOneButtonFactory _popupOneButtonFactory;
        [Inject] private readonly PopupTwoButtonFactory _popupTwoButtonFactory;

        [Inject] private readonly IPopupController _popupController;

        private const string PopupNotificationKey = "PopupNotification";
        private const string PopupOneButtonKey = "PopupOneButton";
        private const string PopupTwoButtonKey = "PopupTwoButton";

        private PopupBase _popup;

        public void CreatePopup<T>(PopupObject config) where T : PopupBase
        {
            var currentPopup = _popupController.Find(config.Name);
            if (currentPopup != null)
                return;

            CreatePopupByType<T>(config);
            if (_popup != null)
                SetDataToPopup(config);
        }

        private void CreatePopupByType<T>(PopupObject config) where T : PopupBase
        {
            switch (config.Type)
            {
                case PopupType.Notification:
                    CreatePopupNotification<T>(config.Name);
                    break;

                case PopupType.OneButton:
                    CreatePopupOneButton<T>(config.Name);
                    break;

                case PopupType.TwoButton:
                    CreatePopupTwoButton<T>(config.Name);
                    break;
            }
        }

        private void CreatePopupNotification<T>(string name) where T : PopupBase
        {
            var currentPopup = _popupController.FindByPart(PopupNotificationKey);
            if (currentPopup != null)
                return;

            _popup = _popupNotificationFactory.Create<T>();

            var gameObjectName = $"{PopupNotificationKey}{name}";
            _popup.SetGameObjectName(gameObjectName);

            _popupController.Add(gameObjectName, _popup.gameObject);
        }
        private void CreatePopupOneButton<T>(string name) where T : PopupBase
        {
            var currentPopup = _popupController.FindByPart(PopupOneButtonKey);
            if (currentPopup != null)
                return;

            _popup = _popupOneButtonFactory.Create<T>();

            var gameObjectName = $"{PopupOneButtonKey}{name}";
            _popup.SetGameObjectName($"{PopupOneButtonKey}{name}");

            _popupController.Add(gameObjectName, _popup.gameObject);
        }
        private void CreatePopupTwoButton<T>(string name) where T : PopupBase
        {
            var currentPopup = _popupController.FindByPart(PopupTwoButtonKey);
            if (currentPopup != null)
                return;

            _popup = _popupTwoButtonFactory.Create<T>();

            var gameObjectName = $"{PopupTwoButtonKey}{name}";
            _popup.SetGameObjectName(gameObjectName);

            _popupController.Add(gameObjectName, _popup.gameObject);
        }

        private void SetDataToPopup(PopupObject config)
        {
            _popup.SetText(config.Text);
            _popup.SetFadeTime(config.FadeTime);
        }
    }
}