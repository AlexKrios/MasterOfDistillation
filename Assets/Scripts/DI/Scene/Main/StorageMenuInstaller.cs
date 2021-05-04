using Scripts.Objects.Product;
using Scripts.UI.Workshop.Storage;
using Scripts.UI.Workshop.Storage.Item;
using Scripts.UI.Workshop.Storage.TypeTab;
using Zenject;

namespace Scripts.DI.Scene.Main
{
    public class StorageMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindFactory<StorageMenuUI, StorageMenuUI.Factory>().FromFactory<StorageMenuUIFactory>();
            Container.BindFactory<TypeTabsGroup, TypeTabsGroup.Factory>().FromFactory<TypeTabFactory>();
            Container.BindFactory<ItemsGroup, ItemsGroup.Factory>().FromFactory<ItemsGroupFactory>();
            Container.BindFactory<ProductFullData, ItemButton, ItemButton.Factory>().FromFactory<ItemButtonFactory>();
        }     
    }
}