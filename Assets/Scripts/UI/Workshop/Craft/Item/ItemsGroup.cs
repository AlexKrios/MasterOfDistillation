using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop.Craft.Item
{
    public class ItemsGroup : MonoBehaviour
    {
        [Inject] private IUiController _uiController;
        [Inject] private ItemButton.Factory _itemFactory;
        [Inject] private CraftMenuUIFactory.Settings _menuSettings;

        private CraftMenuUI _menu;

        [Header("Links")]
        [SerializeField] private RectTransform _container;
        public RectTransform Container { get => _container; }

        private Dictionary<string, ItemButton> _items;
        public Dictionary<string, ItemButton> Items { get => _items; }

        private ItemButton _activeItem;
        public ItemButton ActiveItem
        {
            get { return _activeItem; }
            set
            {
                if (_activeItem != value)
                {
                    if (_activeItem != null)
                    {
                        _activeItem.SetItemInactive();
                    }                    
                    _activeItem = value;
                    _activeItem.SetItemActive();
                    _menu.ProductCell.SetProductIcon(_activeItem.Product.Data.Icon);
                    _menu.QualityBtn.ResetQuality();
                    _menu.PartGroup.SetPartsInfo();
                }
            }
        }

        private void Start()
        {
            _menu = _uiController.FindByPart(_menuSettings.Name).GetComponent<CraftMenuUI>();

            CreateMenuItems();
        }

        public void SubscribeItemToList(ItemButton item)
        {
            if (_items == null)
            {
                _items = new Dictionary<string, ItemButton>();
            }

            _items.Add(item.Product.Data.Name, item);
        }        

        public void CreateMenuItems()
        {
            var keys = _menu.TypeTabs.ActiveTab.Keys;
            foreach (var key in keys)
            {
                var items = _menu.ProductStore.AllStore[key.ToString()];
                foreach (var item in items)
                {
                    var newItem = _itemFactory.Create(item.Value);
                    SubscribeItemToList(newItem);
                }
            }

            ActiveItem = _items.First().Value;

            SetContainerHeight();
        }

        private void SetContainerHeight()
        {
            var itemsGroupSettings = _menuSettings.ItemsGroupSettings;

            var rowCount = (int)Math.Ceiling((double)_items.Count / itemsGroupSettings.RowCount);
            var height = itemsGroupSettings.Height * rowCount + itemsGroupSettings.Padding * (rowCount - 1);

            _container.sizeDelta = new Vector2(_container.sizeDelta.x, height);
        }

        public void ResetMenuItems()
        {
            foreach (var item in _items)
            {
                Destroy(item.Value.gameObject);
            }

            _items.Clear();
        }

        public class Factory : PlaceholderFactory<ItemsGroup> { }
    }
}
