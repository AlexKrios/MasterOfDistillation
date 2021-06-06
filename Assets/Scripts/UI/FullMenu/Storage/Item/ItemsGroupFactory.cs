using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.FullMenu.Storage.Item
{
    [UsedImplicitly]
    public class ItemsGroupFactory : IFactory<ItemsGroup>
    {
        [Inject] private readonly StorageMenuFactory.Settings _storageMenuSettings;
        [Inject] private readonly IUiController _uiController;

        private readonly DiContainer _container;

        public ItemsGroupFactory(DiContainer container)
        {
            _container = container;    
        }

        public ItemsGroup Create()
        {
            var itemsSettings = _storageMenuSettings.ItemsGroupSettings;

            var parent = _uiController.Find(_storageMenuSettings.Name).transform;
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
        }
    }
}
