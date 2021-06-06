using Assets.Scripts.Stores.Product;
using Assets.Scripts.Ui.FullMenu.Common;
using Assets.Scripts.Ui.FullMenu.Common.Item;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

// ReSharper disable UnusedMember.Local
#pragma warning disable 649

namespace Assets.Scripts.Ui.FullMenu.Craft.Item
{
    [UsedImplicitly]
    public class ItemsGroup : MonoBehaviour, IItemsGroup
    {
        [Inject] private readonly CraftMenuFactory.Settings _craftMenuSettings;
        [Inject] private readonly ItemButton.Factory _itemFactory;

        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly IProductStore _productStore;

        private IFullMenu _fullMenu;
        private Dictionary<string, ItemButton> _items;

        [Header("Links")]
        [SerializeField] private RectTransform _container;
        public RectTransform Container => _container;

        private IItemButton ActiveItem
        {
            get => _fullMenu.ActiveItem;
            set => _fullMenu.ActiveItem = value;
        }

        private void Awake()
        {
            _fullMenu = _uiController.Find(_craftMenuSettings.Name).GetComponent<IFullMenu>();
            _fullMenu.Items = this;

            CreateItems();
        }

        private void Start()
        {
            SetInitItem();
        }

        private void SubscribeItemToList(ItemButton item)
        {
            if (_items == null)
                _items = new Dictionary<string, ItemButton>();

            _items.Add(item.Product.Name, item);
        }        

        public void CreateItems()
        {
            if (_items != null)
                ResetItems();

            foreach (var key in _fullMenu.ActiveTab.Keys)
            {
                var items = _productStore.ItemsDictionary.Where(x => x.Value.ProductType == key);
                foreach (var item in items)
                {
                    var newItem = _itemFactory.Create(item.Value);
                    SubscribeItemToList(newItem);
                }
            }

            SetContainerHeight();
        }

        private void SetContainerHeight()
        {
            var itemsGroupSettings = _craftMenuSettings.ItemsGroupSettings;

            var height = itemsGroupSettings.Height * _items.Count + itemsGroupSettings.Padding * (_items.Count + 1);

            _container.sizeDelta = new Vector2(_container.sizeDelta.x, height);
        }

        private void ResetItems()
        {
            foreach (var item in _items)
                Destroy(item.Value.gameObject);

            _items.Clear();
        }

        public void SetInitItem()
        {
            ActiveItem = _items.First().Value;
            ActiveItem.SetItemActive();
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<ItemsGroup> { }
    }
}