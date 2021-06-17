using Assets.Scripts.Ui.Popup.Notification;
using Assets.Scripts.Ui.Popup.OneButton;
using Assets.Scripts.Ui.Popup.TwoButton;
using UnityEngine;
using Zenject;

// ReSharper disable UnassignedField.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Assets.Scripts.DI.Scene.Popup
{
    [CreateAssetMenu(menuName = "DI Settings/Popup")]
    public class PopupSettingsInstaller : ScriptableObjectInstaller<PopupSettingsInstaller>
    {
        public PopupNotificationFactory.Settings PopupWithoutButtonSettings;
        public PopupOneButtonFactory.Settings PopupOneButtonSettings;
        public PopupTwoButtonFactory.Settings PopupTwoButtonSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(PopupWithoutButtonSettings);
            Container.BindInstance(PopupOneButtonSettings);
            Container.BindInstance(PopupTwoButtonSettings);
        }
    }
}