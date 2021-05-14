using Scripts.Objects.Product;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Workshop.Storage.Item
{
    public class ItemButton : MonoBehaviour, IPointerClickHandler
    {
        [Inject] private IUiController _uiController;
        [Inject] private StorageMenuUIFactory.Settings _menuSettings;

        private ItemsGroup _itemGroup;

        [Header("Product cell info")]
        [SerializeField] private Image _background;
        [SerializeField] private Image _icon;
        [SerializeField] private Text _name;

        [Header("Assets")]
        [SerializeField] private Sprite _bgInactive;
        public Sprite BgInactive { get => _bgInactive; }

        [SerializeField] private Sprite _bgActive;
        public Sprite BgActive { get => _bgActive; }

        private ProductFullData _product;
        public ProductFullData Product { get => _product; }

        private void Start() 
        {
            _itemGroup = _uiController.FindByPart(_menuSettings.Name).GetComponent<StorageMenuUI>().ItemsGroup;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _itemGroup.ActiveItem = this;
        }

        public void SetCellInfo(ProductFullData product)
        {
            _product = product;
            _product.GameObject = gameObject;

            SetCellIcon(product.Data.Icon);
            SetCellName(product.Data.Name);
        }

        public void SetItemInactive()
        {
            SetItemBackground(_bgInactive);
        }

        public void SetItemActive()
        {
            SetItemBackground(_bgActive);
        }        

        private void SetItemBackground(Sprite background)
        {
            _background.sprite = background;
        }

        private void SetCellIcon(Sprite icon)
        {
            _icon.sprite = icon;
        }

        private void SetCellName(string name)
        {
            _name.text = name;
        }

        public class Factory : PlaceholderFactory<ProductFullData, ItemButton> { }
    }
}
