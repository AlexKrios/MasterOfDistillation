using Assets.Scripts.Objects.Item.Craft;
using JetBrains.Annotations;
using System;
using Assets.Scripts.Objects.Item;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Craft.Item
{
    [UsedImplicitly]
    public class ItemButtonFactory : IFactory<ICraftable, ItemButton> 
    {
        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly CraftMenuUiFactory.Settings _menuSettings;

        private readonly DiContainer _container;

        public ItemButtonFactory(DiContainer container)
        {
            _container = container;
        }

        public ItemButton Create(ICraftable product)
        {
            var itemSettings = _menuSettings.ItemButtonSettings;

            var parent = _uiController.FindByPart(_menuSettings.Name).GetComponent<CraftMenu>().ItemsGroup.Container;
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
