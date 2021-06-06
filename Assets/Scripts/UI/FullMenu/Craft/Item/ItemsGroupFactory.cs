using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.FullMenu.Craft.Item
{
    [UsedImplicitly]
    public class ItemsGroupFactory : IFactory<ItemsGroup>
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly CraftMenuFactory.Settings _craftMenuSettings;

        [Inject] private readonly IUiController _uiController;

        public ItemsGroup Create()
        {
            var itemsSettings = _craftMenuSettings.ItemsGroupSettings;

            var parent = _uiController.Find(_craftMenuSettings.Name).transform;
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

            public int Padding;
            public int Height;
        }
    }
}
