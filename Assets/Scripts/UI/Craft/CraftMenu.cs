using Scripts.Stores.Product;
using Scripts.UI.Craft.Create;
using Scripts.UI.Craft.Item;
using Scripts.UI.Craft.Part;
using Scripts.UI.Craft.Product;
using Scripts.UI.Craft.Quality;
using Scripts.UI.Craft.TypeTab;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Craft
{
    public class CraftMenu : MonoBehaviour
    {
        [Inject] private TypeTabsGroup.Factory _typeTabsFactory;
        [Inject] private ItemsGroup.Factory _itemGroupFactory;

        [Inject] private IProductStore _productStore;
        public IProductStore ProductStore { get => _productStore; }

        [Header("Components")]
        [SerializeField] private Text _title;
        public Text Title { get => _title; }
        public TypeTabsGroup TypeTabs { get; set; }
        public ItemsGroup ItemsGroup { get; private set; }

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
            TypeTabs = _typeTabsFactory.Create();
            ItemsGroup = _itemGroupFactory.Create();
        }

        public class Factory : PlaceholderFactory<CraftMenu> { }
    }
}
