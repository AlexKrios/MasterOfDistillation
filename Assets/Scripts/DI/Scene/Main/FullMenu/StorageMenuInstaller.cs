using Assets.Scripts.Objects.Item;
using Assets.Scripts.Ui.FullMenu.Storage;
using Assets.Scripts.Ui.FullMenu.Storage.Item;
using Zenject;

namespace Assets.Scripts.DI.Scene.Main.FullMenu
{
    public class StorageMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindFactory<StorageMenu, StorageMenu.Factory>().FromFactory<StorageMenuFactory>();

            Container.BindFactory<ItemsGroup, ItemsGroup.Factory>().FromFactory<ItemsGroupFactory>();
            Container.BindFactory<ICraftable, ItemButton, ItemButton.Factory>().FromFactory<ItemButtonFactory>();
        }     
    }
}