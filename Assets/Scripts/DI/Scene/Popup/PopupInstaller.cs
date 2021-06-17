using Assets.Scripts.Ui.Popup;
using Assets.Scripts.Ui.Popup.Notification;
using Assets.Scripts.Ui.Popup.OneButton;
using Assets.Scripts.Ui.Popup.TwoButton;
using Zenject;

namespace Assets.Scripts.DI.Scene.Popup
{
    public class PopupInstaller : MonoInstaller<PopupInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IPopupController>().To<PopupController>().AsSingle().NonLazy();
            Container.Bind<IPopupFactory>().To<PopupFactory>().AsSingle().NonLazy();

            Container.Bind<PopupConfig>().AsSingle().NonLazy();

            Container.Bind<PopupNotificationFactory>().AsSingle().NonLazy();
            Container.Bind<PopupOneButtonFactory>().AsSingle().NonLazy();
            Container.Bind<PopupTwoButtonFactory>().AsSingle().NonLazy();
        }
    }
}