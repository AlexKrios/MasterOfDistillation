using System;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop.Craft.Item
{
    public class ItemsGroupFactory : IFactory<ItemsGroup>
    {
        [Inject] private IUiController _uiController;
        [Inject] private Settings _settings;
        [Inject] private CraftMenuUIFactory.Settings _menuSettings;

        private DiContainer _container;
        private ItemsGroup _itemGroup;

        public ItemsGroupFactory(DiContainer container)
        {
            _container = container;    
        }

        public ItemsGroup Create()
        {
            var parent = _uiController.FindByPart(_menuSettings.Name).transform;

            _itemGroup = _container.InstantiatePrefabForComponent<ItemsGroup>(_settings.Prefab, parent);
            _itemGroup.name = _settings.Name;

            _itemGroup.transform.SetSiblingIndex(2);

            return _itemGroup;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;
        }
    }
}
