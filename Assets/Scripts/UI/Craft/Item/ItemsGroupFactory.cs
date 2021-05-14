using System;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Craft.Item
{
    public class ItemsGroupFactory : IFactory<ItemsGroup>
    {
        [Inject] private IUiController _uiController;
        [Inject] private CraftMenuUIFactory.Settings _menuSettings;

        private DiContainer _container;

        public ItemsGroupFactory(DiContainer container)
        {
            _container = container;    
        }

        public ItemsGroup Create()
        {
            var itemsSettings = _menuSettings.ItemsGroupSettings;

            var parent = _uiController.FindByPart(_menuSettings.Name).transform;
            var itemGroup = _container.InstantiatePrefabForComponent<ItemsGroup>(itemsSettings.Prefab, parent);
            itemGroup.name = itemsSettings.Name;

            itemGroup.transform.SetSiblingIndex(2);

            return itemGroup;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;

            public int RowCount;
            public int Padding;
            public int Height;
        }
    }
}
