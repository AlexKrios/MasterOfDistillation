using Scripts.Api;
using Scripts.Common.Craft;
using Scripts.Common.Craft.Action;
using Scripts.Stores;
using Scripts.Stores.Level;
using Scripts.Stores.Money;
using Scripts.Stores.Product;
using Scripts.Stores.Raw;
using Scripts.Timer.Raw;
using Scripts.UI;
using Scripts.UI.Level;
using Scripts.UI.Money;
using Scripts.UI.Raw;
using Zenject;

namespace Scripts.DI.Game
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameManager>().AsSingle().NonLazy();
            
            InstallApi();            
            InstallStores();
            InstallUIComponents();

            InstallCraftComponents();
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

            Container.Bind<IStore>().To<ProductStore>().AsSingle();
        }

        private void InstallUIComponents()
        {
            Container.Bind<IUiController>().To<UiController>().AsSingle().NonLazy();

            Container.Bind<IMoneyUIController>().To<MoneyUIController>().AsSingle().NonLazy();
            Container.Bind<ILevelUIController>().To<LevelUIController>().AsSingle().NonLazy();
            Container.Bind<IRawUIController>().To<RawUIController>().AsSingle().NonLazy();
        }

        private void InstallCraftComponents()
        {
            Container.Bind<ICraftController>().To<CraftController>().AsSingle().NonLazy();

            Container.Bind<CraftAction>().AsSingle().NonLazy();
            Container.Bind<RawAction>().AsSingle().NonLazy();
        }
    }
}