using Scripts.Common.Craft;
using Scripts.Scenes.Main.MainCamera;
using Scripts.UI.Level;
using Scripts.UI.Money;
using Scripts.UI.Product;
using Scripts.UI.Raw;
using Scripts.UI.Workshop;
using Zenject;

namespace Scripts.DI.Scene.Main
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallCameraComponents();
            InstallUIFactory();

            InstallCraftComponents();
        }

        private void InstallCameraComponents()
        {
            Container.Bind<IDisable>().To<Disable>().AsSingle().NonLazy();
            Container.Bind<ITarget>().To<Target>().AsSingle().NonLazy();
        }

        private void InstallUIFactory()
        {
            Container.BindFactory<MoneyUI, MoneyUI.Factory>().FromFactory<MoneyUIFactory>();
            Container.BindFactory<LevelUI, LevelUI.Factory>().FromFactory<LevelUIFactory>();
            Container.BindFactory<RawUI, RawUI.Factory>().FromFactory<RawUIFactory>();
            Container.BindFactory<ComponentUI, ComponentUI.Factory>().FromFactory<ComponentUIFactory>();
            Container.BindFactory<string, ProductUI, ProductUI.Factory>().FromFactory<ProductUIFactory>();

            Container.BindFactory<string, WorkshopMenu, WorkshopMenu.Factory>().FromFactory<WorkshopMenuFactory>();
        }

        private void InstallCraftComponents()
        {
            Container.Bind<ICraftController>().To<CraftController>().AsSingle().NonLazy();
            
            Container.Bind<CraftComponent>().AsSingle().NonLazy();
            Container.Bind<RawAction>().AsSingle().NonLazy();
            Container.Bind<ComponentAction>().AsSingle().NonLazy();
        }
    }
}