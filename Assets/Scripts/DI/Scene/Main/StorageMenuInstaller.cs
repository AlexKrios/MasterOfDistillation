using Assets.Scripts.Objects.Product.Data;
using Assets.Scripts.UI.Storage;
using Assets.Scripts.UI.Storage.Item;
using Assets.Scripts.UI.Storage.TypeTab;
using Zenject;

namespace Assets.Scripts.DI.Scene.Main
{
    public class StorageMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindFactory<StorageMenuUi, StorageMenuUi.Factory>().FromFactory<StorageMenuUiFactory>();
            Container.BindFactory<TypeTabsGroup, TypeTabsGroup.Factory>().FromFactory<TypeTabFactory>();
            Container.BindFactory<ItemsGroup, ItemsGroup.Factory>().FromFactory<ItemsGroupFactory>();
            Container.BindFactory<ProductFullData, ItemButton, ItemButton.Factory>().FromFactory<ItemButtonFactory>();
        }     
    }
}