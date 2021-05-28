using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Craft.Item
{
    [UsedImplicitly]
    public class ItemsGroupFactory : IFactory<ItemsGroup>
    {
        [Inject] private readonly CraftMenuUiFactory.Settings _craftMenuSettings;
        [Inject] private readonly IUiController _uiController;

        private readonly DiContainer _container;

        public ItemsGroupFactory(DiContainer container)
        {
            _container = container;    
        }

        public ItemsGroup Create()
        {
            var itemsSettings = _craftMenuSettings.ItemsGroupSettings;

            var parent = _uiController.FindByPart(_craftMenuSettings.Name).transform;
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
