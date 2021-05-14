using Scripts.Common.Craft.Action;
using Scripts.Objects.Product;
using Scripts.Scenes.Main.MainCamera;
using Scripts.UI.Level;
using Scripts.UI.Money;
using Scripts.UI.Raw;
using Scripts.UI.Craft;
using Scripts.UI.Craft.Item;
using Scripts.UI.Craft.TypeTab;
using Zenject;

namespace Scripts.DI.Scene.Main
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallCameraComponents();
            InstallUIFactory();

            InstallCraftMenu();
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

            Container.BindFactory<CraftMenu, CraftMenu.Factory>().FromFactory<CraftMenuUIFactory>();
            Container.BindFactory<TypeTabsGroup, TypeTabsGroup.Factory>().FromFactory<TypeTabFactory>();
            Container.BindFactory<ItemsGroup, ItemsGroup.Factory>().FromFactory<ItemsGroupFactory>();
            Container.BindFactory<ProductFullData, ItemButton, ItemButton.Factory>().FromFactory<ItemButtonFactory>();
        }

        private void InstallCraftMenu()
        {
            Container.Bind<CraftAction>().AsSingle().NonLazy();

            Container.Bind<ICraftPartAction>().To<RawAction>().AsSingle().NonLazy();
            Container.Bind<ICraftPartAction>().To<ComponentAction>().AsSingle().NonLazy();
        }
    }
}