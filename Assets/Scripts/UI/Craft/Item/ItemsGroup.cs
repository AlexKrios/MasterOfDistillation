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
    public class ItemsGroup : MonoBehaviour
    {
        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly ItemButton.Factory _itemFactory;
        [Inject] private readonly CraftMenuUiFactory.Settings _menuSettings;

        private CraftMenu _menu;

        [Header("Links")]
        [SerializeField] private RectTransform _container;
        public RectTransform Container => _container;
        public Dictionary<string, ItemButton> Items { get; private set; }

        private ItemButton _activeItem;
        public ItemButton ActiveItem
        {
            get => _activeItem;
            set
            {
                if (_activeItem == value)
                {
                    return;
                }
                if (_activeItem != null)
                {
                    _activeItem.SetItemInactive();
                }                    
                _activeItem = value;
                _activeItem.SetItemActive();
                _menu.ProductCell.SetProductIcon(_activeItem.Product.Icon);
                _menu.QualityBtn.ResetQuality();
                _menu.PartGroup.SetPartsInfo();
            }
        }

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            _menu = _uiController.FindByPart(_menuSettings.Name).GetComponent<CraftMenu>();

            CreateMenuItems();
        }

        public void SubscribeItemToList(ItemButton item)
        {
            if (Items == null)
            {
                Items = new Dictionary<string, ItemButton>();
            }

            Items.Add(item.Product.Name, item);
        }        

        public void CreateMenuItems()
        {
            var keys = _menu.TypeTabs.ActiveTab.Keys;
            foreach (var key in keys)
            {
                var items = _menu.ProductStore.Store.Where(x => x.Value.ProductType == key);
                foreach (var item in items)
                {
                    var newItem = _itemFactory.Create(item.Value);
                    SubscribeItemToList(newItem);
                }
            }

            ActiveItem = Items.First().Value;

            SetContainerHeight();
        }

        private void SetContainerHeight()
        {
            var itemsGroupSettings = _menuSettings.ItemsGroupSettings;

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

        public class Factory : PlaceholderFactory<ItemsGroup> { }
    }
}
