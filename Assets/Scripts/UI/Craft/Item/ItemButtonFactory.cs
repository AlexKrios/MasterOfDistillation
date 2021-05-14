using Scripts.Objects.Product;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Craft.Item
{
    public class ItemButtonFactory : IFactory<ProductFullData, ItemButton> 
    {
        [Inject] private IUiController _uiController;
        [Inject] private CraftMenuUIFactory.Settings _menuSettings;

        private DiContainer _container;

        public ItemButtonFactory(DiContainer container)
        {
            _container = container;
        }

        public ItemButton Create(ProductFullData product)
        {
            var itemSettings = _menuSettings.ItemButtonSettings;

            var parent = _uiController.FindByPart(_menuSettings.Name).GetComponent<CraftMenu>().ItemsGroup.Container;
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
