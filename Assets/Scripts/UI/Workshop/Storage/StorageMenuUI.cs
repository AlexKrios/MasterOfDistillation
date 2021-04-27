using Scripts.Stores;
using Scripts.UI.Workshop.Craft.Create;
using Scripts.UI.Workshop.Craft.Item;
using Scripts.UI.Workshop.Craft.Part;
using Scripts.UI.Workshop.Craft.Product;
using Scripts.UI.Workshop.Craft.Quality;
using Scripts.UI.Workshop.Craft.TypeTab;
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
        public TypeTabsGroup TypeTabs 
        {
            get { return _typeTabs; }
            set { _typeTabs = value; }
        }

        private ItemsGroup _itemsGroup;
        public ItemsGroup ItemsGroup { get => _itemsGroup; }

        [SerializeField] private ProductCell _productCell;
        public ProductCell ProductCell { get => _productCell; }

        [SerializeField] private PartGroup _partGroup;
        public PartGroup PartGroup { get => _partGroup; }

        [SerializeField] private CreateButton _createBtn;
        public CreateButton CreateBtn { get => _createBtn; }

        [SerializeField] private QualityButton _qualityBtn;
        public QualityButton QualityBtn { get => _qualityBtn; }

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
