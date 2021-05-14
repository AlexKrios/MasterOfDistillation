using Assets.Scripts.Stores.Product;
using Assets.Scripts.UI.Craft.Create;
using Assets.Scripts.UI.Craft.Item;
using Assets.Scripts.UI.Craft.Part;
using Assets.Scripts.UI.Craft.Product;
using Assets.Scripts.UI.Craft.Quality;
using Assets.Scripts.UI.Craft.TypeTab;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
#pragma warning disable 649

namespace Assets.Scripts.UI.Craft
{
    public class CraftMenu : MonoBehaviour
    {
        [Inject] private readonly TypeTabsGroup.Factory _typeTabsFactory;
        [Inject] private readonly ItemsGroup.Factory _itemGroupFactory;

        [Inject] private readonly IProductStore _productStore;
        public IProductStore ProductStore => _productStore;

        [Header("Components")]
        [SerializeField] private Text _title;
        public Text Title => _title;
        public TypeTabsGroup TypeTabs { get; set; }
        public ItemsGroup ItemsGroup { get; private set; }

        [SerializeField] private ProductCell _productCell;
        public ProductCell ProductCell => _productCell;

        [SerializeField] private PartGroup _partGroup;
        public PartGroup PartGroup => _partGroup;

        [SerializeField] private CreateButton _createBtn;
        public CreateButton CreateBtn => _createBtn;

        [SerializeField] private QualityButton _qualityBtn;
        public QualityButton QualityBtn => _qualityBtn;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {           
            TypeTabs = _typeTabsFactory.Create();
            ItemsGroup = _itemGroupFactory.Create();
        }

        public class Factory : PlaceholderFactory<CraftMenu> { }
    }
}
