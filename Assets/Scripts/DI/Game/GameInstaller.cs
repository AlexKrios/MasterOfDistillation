using Scripts.Api;
using Scripts.Common.Craft;
using Scripts.Common.Craft.Weapon.Rifle;
using Scripts.Scenes.Main;
using Scripts.Stores.Level;
using Scripts.Stores.Money;
using Scripts.Stores.Product;
using Scripts.Stores.Product.Weapon.Rifle;
using Scripts.Stores.Raw;
using Scripts.UI;
using Scripts.UI.Level;
using Scripts.UI.Money;
using Scripts.UI.Product;
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
            InstallUIComponents();
            InstallStores();
        }

        private void InstallApi()
        {
            Container.Bind<IApiManager>().To<ApiManager>().AsSingle().NonLazy();
        }

        private void InstallUIComponents()
        {
            Container.Bind<IUiController>().To<UiController>().AsSingle().NonLazy();

            Container.Bind<IMoneyUIController>().To<MoneyUIController>().AsSingle().NonLazy();
            Container.Bind<ILevelUIController>().To<LevelUIController>().AsSingle().NonLazy();
            Container.Bind<IRawUIController>().To<RawUIController>().AsSingle().NonLazy();

            Container.Bind<IProductUIController>()
                .To<RifleUIController>()
                .AsSingle()
                .WhenInjectedInto(typeof(RifleStore), typeof(CraftComponent))
                .NonLazy();
        }

        private void InstallStores()
        {
            Container.Bind<IRecipesStore>().To<RecipesStore>().AsSingle().NonLazy();

            Container.Bind<IMoneyStore>().To<MoneyStore>().AsSingle().NonLazy();
            Container.Bind<ILevelStore>().To<LevelStore>().AsSingle().NonLazy();            
            Container.Bind<IRawStore>().To<RawStore>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<RifleStore>()
                .AsSingle()
                .WhenInjectedInto(typeof(InitManager), typeof(RifleCraft), typeof(RifleUIController))
                .NonLazy();
        }        
    }
}