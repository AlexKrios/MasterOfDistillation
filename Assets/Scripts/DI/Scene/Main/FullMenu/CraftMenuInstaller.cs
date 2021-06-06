using Assets.Scripts.Objects.Item;
using Assets.Scripts.Ui.FullMenu.Craft.Controller.Action;
using Assets.Scripts.Ui.FullMenu.Craft.Create;
using Assets.Scripts.Ui.FullMenu.Craft.Item;
using Zenject;

namespace Assets.Scripts.DI.Scene.Main.FullMenu
{
    public class CraftMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindFactory<ItemsGroup, ItemsGroup.Factory>().FromFactory<ItemsGroupFactory>();
            Container.BindFactory<ICraftable, ItemButton, ItemButton.Factory>().FromFactory<ItemButtonFactory>();

            Container.BindFactory<CreateButton, CreateButton.Factory>().FromFactory<CreateButtonFactory>();

            Container.Bind<ICraftPartAction>().To<RawAction>().AsSingle().NonLazy();
            Container.Bind<ICraftPartAction>().To<ComponentAction>().AsSingle().NonLazy();
        }     
    }
}