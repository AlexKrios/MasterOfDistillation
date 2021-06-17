using Assets.Scripts.Stores.Craft;
using Assets.Scripts.Ui.FullMenu.Common;
using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Ui.FullMenu.Craft.Item
{
    [UsedImplicitly]
    public class ItemButtonFactory : IFactory<ICraftable, ItemButton> 
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly CraftMenuFactory.Settings _craftMenuSettings;

        [Inject] private readonly IUiController _uiController;

        public ItemButton Create(ICraftable product)
        {
            var itemSettings = _craftMenuSettings.ItemButtonSettings;

            var parent = _uiController.Find(_craftMenuSettings.Name).GetComponent<IFullMenu>().Items.Container;
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
