using Assets.Scripts.Objects.Item;
using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Storage.Item
{
    [UsedImplicitly]
    public class ItemButtonFactory : IFactory<ICraftable, ItemButton> 
    {
        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly StorageMenuUiFactory.Settings _menuSettings;

        private readonly DiContainer _container;

        public ItemButtonFactory(DiContainer container)
        {
            _container = container;
        }

        public ItemButton Create(ICraftable product)
        {
            var itemSettings = _menuSettings.ItemButtonSettings;

            var parent = _uiController.FindByPart(_menuSettings.Name).GetComponent<StorageMenuUi>().ItemsGroup.Container;
            var item = _container.InstantiatePrefabForComponent<ItemButton>(itemSettings.Prefab, parent);

            item.SetCellInfo(product);
            item.name = product.Name;

            return item;
        }

        [Serializable]
        public class Settings
        {
            [UsedImplicitly] public GameObject Prefab;
        }
    }
}
