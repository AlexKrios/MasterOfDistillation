using Assets.Scripts.Controllers.Product;
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

namespace Assets.Scripts.Ui.FullMenu.Storage.Item
{
    [UsedImplicitly]
    public class ItemsGroup : MonoBehaviour, IItemsGroup
    {
        [Inject] private readonly StorageMenuFactory.Settings _storageMenuSettings;
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
            _fullMenu = _uiController.Find(_storageMenuSettings.Name).GetComponent<StorageMenu>();
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

            var keys = _fullMenu.ActiveTab.Keys;
            foreach (var key in keys)
            {
                var items = _productStore.ItemsDictionary.Where(x => x.Value.ProductType == key);
                foreach (var item in items)
                {
                    if (!ProductCountController.CheckIfHaveCount(item.Value))
                        continue;

                    var newItem = _itemFactory.Create(item.Value);
                    SubscribeItemToList(newItem);
                }
            }
        }

        public void SetInitItem()
        {
            ActiveItem = _items.First().Value;
            ActiveItem.SetItemActive();
        }

        private void ResetItems()
        {
            foreach (var item in _items)
                Destroy(item.Value.gameObject);

            _items.Clear();
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<ItemsGroup> { }
    }
}
