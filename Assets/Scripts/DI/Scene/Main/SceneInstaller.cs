using Assets.Scripts.Common.Craft.Action;
using Assets.Scripts.Objects.Item;
using Assets.Scripts.Scenes.Main.MainCamera.Disable;
using Assets.Scripts.Scenes.Main.MainCamera.Target;
using Assets.Scripts.UI.Craft;
using Assets.Scripts.UI.Craft.Item;
using Assets.Scripts.UI.Craft.TypeTab;
using Assets.Scripts.UI.Level;
using Assets.Scripts.UI.Money;
using Assets.Scripts.UI.Raw;
using Zenject;

namespace Assets.Scripts.DI.Scene.Main
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallCameraComponents();
            InstallUiFactory();

            InstallCraftMenu();
        }

        private void InstallCameraComponents()
        {
            Container.Bind<IDisable>().To<Disable>().AsSingle().NonLazy();
            Container.Bind<ITarget>().To<Target>().AsSingle().NonLazy();
        }

        private void InstallUiFactory()
        {
            Container.BindFactory<MoneyUi, MoneyUi.Factory>().FromFactory<MoneyUiFactory>();
            Container.BindFactory<LevelUi, LevelUi.Factory>().FromFactory<LevelUiFactory>();
            Container.BindFactory<RawUi, RawUi.Factory>().FromFactory<RawUiFactory>();

            Container.BindFactory<CraftMenu, CraftMenu.Factory>().FromFactory<CraftMenuUiFactory>();
            Container.BindFactory<TypeTabsGroup, TypeTabsGroup.Factory>().FromFactory<TypeTabFactory>();
            Container.BindFactory<ItemsGroup, ItemsGroup.Factory>().FromFactory<ItemsGroupFactory>();
            Container.BindFactory<ICraftable, ItemButton, ItemButton.Factory>().FromFactory<ItemButtonFactory>();
        }

        private void InstallCraftMenu()
        {
            //Container.Bind<ICraftController>().To<CraftController>().AsSingle().NonLazy();

            Container.Bind<ICraftPartAction>().To<RawAction>().AsSingle().NonLazy();
            Container.Bind<ICraftPartAction>().To<ComponentAction>().AsSingle().NonLazy();
        }
    }
}