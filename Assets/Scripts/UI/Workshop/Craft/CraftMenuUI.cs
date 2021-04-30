﻿using Scripts.Stores;
using Scripts.UI.Workshop.Craft.Create;
using Scripts.UI.Workshop.Craft.Item;
using Scripts.UI.Workshop.Craft.Part;
using Scripts.UI.Workshop.Craft.Product;
using Scripts.UI.Workshop.Craft.Quality;
using Scripts.UI.Workshop.Craft.TypeTab;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Workshop.Craft
{
    public class CraftMenuUI : MonoBehaviour
    {
        [Inject] private TypeTabsGroup.Factory _typeTabsFactory;
        [Inject] private ItemsGroup.Factory _itemGroupFactory;

        [Inject] private IStore _productStore;
        public IStore ProductStore { get => _productStore; }

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
            _typeTabs = _typeTabsFactory.Create();
            _itemsGroup = _itemGroupFactory.Create();
        }

        public class Factory : PlaceholderFactory<CraftMenuUI> { }
    }
}
