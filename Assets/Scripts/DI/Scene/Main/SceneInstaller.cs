using Scripts.Scenes.Main.Buildings.Workshop.UI;
using Scripts.Scenes.Main.Craft;
using Scripts.Scenes.Main.MainCamera;
using Scripts.UI;
using Scripts.UI.Level;
using Scripts.UI.Money;
using Zenject;

namespace Scripts.DI.Scene.Main
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallCameraComponents();
            InstallUIFactory();
            InstallUIComponents();

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

            Container.BindFactory<string, WorkshopMenu, WorkshopMenu.Factory>().FromFactory<WorkshopMenuFactory>();
        }

        private void InstallUIComponents()
        {
            Container.Bind<IUiController>().To<UiController>().AsSingle().NonLazy();

            Container.Bind<IMoneyUIController>().To<MoneyUIController>().AsSingle().NonLazy();
            Container.Bind<ILevelUIController>().To<LevelUIController>().AsSingle().NonLazy();
        }

        private void InstallCraftComponents()
        {
            Container.Bind<ICraftController>().To<CraftController>().AsSingle().NonLazy();

            Container.Bind<CraftIngridient>().AsSingle().NonLazy();
        }
    }
}