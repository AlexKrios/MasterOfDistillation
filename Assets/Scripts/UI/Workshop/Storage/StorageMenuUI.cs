using Scripts.Stores;
using Scripts.UI.Workshop.Storage.Item;
using Scripts.UI.Workshop.Craft.Product;
using Scripts.UI.Workshop.Storage.TypeTab;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Workshop.Storage
{
    public class StorageMenuUI : MonoBehaviour
    {
        [Inject] private TypeTabsGroup.Factory _typeTabsFactory;
        [Inject] private ItemsGroup.Factory _itemGroupFactory;

        [Inject] private List<IStore> _storeList;
        private Dictionary<string, IStore> _stores;
        public Dictionary<string, IStore> Stores { get => _stores; }

        [Header("Components")]
        [SerializeField] private Text _title;
        public Text Title { get => _title; }

        private TypeTabsGroup _typeTabs;
        public TypeTabsGroup TypeTabs { get => _typeTabs; }

        private ItemsGroup _itemsGroup;
        public ItemsGroup ItemsGroup { get => _itemsGroup; }

        [SerializeField] private ProductCell _productCell;
        public ProductCell ProductCell { get => _productCell; }

        private void Start()
        {
            SubscribeStoresToDictionaty();
            
            _typeTabs = _typeTabsFactory.Create();
            _itemsGroup = _itemGroupFactory.Create();
        }

        private void SubscribeStoresToDictionaty()
        {
            _stores = new Dictionary<string, IStore>();
            foreach (var store in _storeList)
            {
                _stores.Add(store.ItemSubType, store);
            }
        }

        public class Factory : PlaceholderFactory<StorageMenuUI> { }
    }
}
