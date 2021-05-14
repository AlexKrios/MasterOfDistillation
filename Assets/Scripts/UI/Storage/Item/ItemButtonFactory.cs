using System;
using Assets.Scripts.Objects.Product.Data;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Storage.Item
{
    public class ItemButtonFactory : IFactory<ProductFullData, ItemButton> 
    {
        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly StorageMenuUiFactory.Settings _menuSettings;

        private readonly DiContainer _container;

        public ItemButtonFactory(DiContainer container)
        {
            _container = container;
        }

        public ItemButton Create(ProductFullData product)
        {
            var itemSettings = _menuSettings.ItemButtonSettings;

            var parent = _uiController.FindByPart(_menuSettings.Name).GetComponent<StorageMenuUi>().ItemsGroup.Container;
            var item = _container.InstantiatePrefabForComponent<ItemButton>(itemSettings.Prefab, parent);

            item.SetCellInfo(product);
            item.name = product.Data.Name;

            return item;
        }

        [Serializable]
        public class Settings
        {
            public GameObject Prefab;
        }
    }
}
