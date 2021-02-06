using Scripts.Api;
using Scripts.Scenes.Main.Craft.Weapon.Rifle;
using Scripts.Stores;
using Scripts.Stores.Level;
using Scripts.Stores.Money;
using Scripts.Stores.Product.Weapon.Rifle;
using Scripts.Stores.Raw;
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

            Container.Bind<IProductStore>().To<RifleStore>().AsSingle().WhenInjectedInto<RifleCraft>().NonLazy();
        }        
    }
}