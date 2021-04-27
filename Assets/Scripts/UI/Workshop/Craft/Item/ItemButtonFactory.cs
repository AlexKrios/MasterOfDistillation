using System;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop.Craft.Item
{
    public class ItemButtonFactory : IFactory<ProductData, ItemButton> 
    {
        [Inject] private IUiController _uiController;
        [Inject] private Settings _settings;
        [Inject] private CraftMenuUIFactory.Settings _menuSettings;

        private DiContainer _container;

        public ItemButtonFactory(DiContainer container)
        {
            _container = container;
        }

        public ItemButton Create(ProductData product)
        {
            var parent = _uiController.FindByPart(_menuSettings.Name).GetComponent<CraftMenuUI>().ItemsGroup.Container;
            var item = _container.InstantiatePrefabForComponent<ItemButton>(_settings.Prefab, parent);

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
