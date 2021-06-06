using Assets.Scripts.Api;
using Assets.Scripts.Stores.Level;
using Assets.Scripts.Stores.Money;
using Assets.Scripts.Stores.Product;
using Assets.Scripts.Stores.Raw;
using Assets.Scripts.Timer.Raw;
using Assets.Scripts.Ui;
using Assets.Scripts.Ui.Popup;
using Assets.Scripts.Ui.Raw;
using Zenject;

namespace Assets.Scripts.Di.Game
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameManager>().AsSingle().NonLazy();
            
            InstallApi();            
            InstallStores();
            InstallUiComponents();
        }

        private void InstallApi()
        {
            Container.Bind<IApiManager>().To<ApiManager>().AsSingle().NonLazy();
        }

        private void InstallStores()
        {
            Container.Bind<IMoneyStore>().To<MoneyStore>().AsSingle().NonLazy();
            Container.Bind<ILevelStore>().To<LevelStore>().AsSingle().NonLazy();

            Container.Bind<IRawStore>().To<RawStore>().AsSingle().NonLazy();
            Container.Bind<IRawTimerController>().To<RawTimerController>().AsSingle().NonLazy();

            Container.Bind<IProductStore>().To<ProductStore>().AsSingle();
            Container.Bind<ProductLevelStore>().AsSingle();
        }

        private void InstallUiComponents()
        {
            Container.Bind<IUiController>().To<UiController>().AsSingle().NonLazy();
            Container.Bind<IPopupController>().To<PopupController>().AsSingle().NonLazy();

            Container.Bind<IRawUiController>().To<RawUiController>().AsSingle().NonLazy();
        }
    }
}