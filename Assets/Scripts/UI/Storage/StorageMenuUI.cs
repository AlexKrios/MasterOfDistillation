using Assets.Scripts.Stores.Product;
using Assets.Scripts.UI.Craft.Product;
using Assets.Scripts.UI.Storage.Item;
using Assets.Scripts.UI.Storage.TypeTab;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
#pragma warning disable 649

namespace Assets.Scripts.UI.Storage
{
    public class StorageMenuUi : MonoBehaviour
    {
        [Inject] private TypeTabsGroup.Factory _typeTabsFactory;
        [Inject] private ItemsGroup.Factory _itemGroupFactory;

        [Inject] private IProductStore _productStore;
        public IProductStore ProductStore => _productStore;

        [Header("Components")]
        [SerializeField] private Text _title;
        public Text Title => _title;

        public TypeTabsGroup TypeTabs { get; private set; }

        public ItemsGroup ItemsGroup { get; private set; }

        [SerializeField] private ProductCell _productCell;
        public ProductCell ProductCell => _productCell;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {           
            TypeTabs = _typeTabsFactory.Create();
            ItemsGroup = _itemGroupFactory.Create();
        }

        public class Factory : PlaceholderFactory<StorageMenuUi> { }
    }
}
