using Assets.Scripts.Stores.Product;
using Assets.Scripts.Ui.Craft;
using Assets.Scripts.Ui.Craft.Item;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
#pragma warning disable 649

namespace Assets.Scripts.UI.Craft.Item
{
    [UsedImplicitly]
    public class ItemsGroup : MonoBehaviour, IItemsGroup
    {
        [Inject] private readonly CraftMenuUiFactory.Settings _craftMenuSettings;
        [Inject] private readonly ItemButton.Factory _itemFactory;

        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly IProductStore _productStore;

        private ICraftMenu _menu;

        [Header("Links")]
        [SerializeField] private RectTransform _container;
        public RectTransform Container => _container;
        public Dictionary<string, ItemButton> Items { get; set; }
        public IItemButton ActiveItem { get; set; }

        // ReSharper disable once UnusedMember.Local
        private void Awake()
        {
            _menu = _uiController.FindByPart(_craftMenuSettings.Name).GetComponent<ICraftMenu>();
        }

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            CreateMenuItems();
        }

        private void SubscribeItemToList(ItemButton item)
        {
            if (Items == null)
            {
                Items = new Dictionary<string, ItemButton>();
            }

            Items.Add(item.Product.Name, item);
        }        

        public void CreateMenuItems()
        {
            var keys = _menu.Tabs.ActiveTab.Keys;
            foreach (var key in keys)
            {
                var items = _productStore.Store.Where(x => x.Value.ProductType == key);
                foreach (var item in items)
                {
                    var newItem = _itemFactory.Create(item.Value);
                    SubscribeItemToList(newItem);
                }
            }

            ActiveItem = Items.First().Value;
            ActiveItem.SetItemActive();

            SetContainerHeight();
        }

        private void SetContainerHeight()
        {
            var itemsGroupSettings = _craftMenuSettings.ItemsGroupSettings;

            var rowCount = (int)Math.Ceiling((double)Items.Count / itemsGroupSettings.RowCount);
            var height = itemsGroupSettings.Height * rowCount + itemsGroupSettings.Padding * (rowCount - 1);

            _container.sizeDelta = new Vector2(_container.sizeDelta.x, height);
        }

        public void ResetMenuItems()
        {
            foreach (var item in Items)
            {
                Destroy(item.Value.gameObject);
            }

            Items.Clear();
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<ItemsGroup> { }
    }
}
