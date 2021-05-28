using Assets.Scripts.Objects.Item;
using Assets.Scripts.Ui.Craft;
using Assets.Scripts.Ui.Craft.Item;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;
#pragma warning disable 649

namespace Assets.Scripts.UI.Craft.Item
{
    [UsedImplicitly]
    public class ItemButton : MonoBehaviour, IItemButton, IPointerClickHandler
    {
        #region Links

        [Inject] private readonly CraftMenuUiFactory.Settings _craftMenuSettings;
        [Inject] private readonly IUiController _uiController;

        private ICraftMenu _menu;
        private IItemsGroup _itemGroup;
        private IItemButton ActiveItem
        {
            get => _itemGroup?.ActiveItem;
            set => _itemGroup.ActiveItem = value;
        }

        #endregion

        #region Assets

        [Header("Assets")]
        [SerializeField] private Image _background;
        [SerializeField] private Image _icon;
        [SerializeField] private Text _name;

        [SerializeField] private Sprite _bgInactive;
        public Sprite BgInactive => _bgInactive;

        [SerializeField] private Sprite _bgActive;
        public Sprite BgActive => _bgActive;

        #endregion
        
        public ICraftable Product { get; private set; }

        // ReSharper disable once UnusedMember.Local
        private void Awake() 
        {
            _menu = _uiController.FindByPart(_craftMenuSettings.Name).GetComponent<ICraftMenu>();
            _itemGroup = _menu.Items;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if ((ItemButton)ActiveItem == this)
            {
                return;
            }

            ActiveItem?.SetItemInactive();
            ActiveItem = this;
            ActiveItem.SetItemActive();
        }

        public void SetCellInfo(ICraftable product)
        {
            Product = product;
            Product.GameObject = gameObject;

            SetCellIcon(product.Icon);
            SetCellName(product.Name);
        }

        public void SetItemInactive()
        {
            SetItemBackground(_bgInactive);
        }

        public void SetItemActive()
        {
            SetItemBackground(_bgActive);

            _menu.Product.SetProductIcon(ActiveItem.Product.Icon);
            _menu.QualityBtn.ResetQuality();
            _menu.PartGroup.SetPartsInfo();
        }        

        private void SetItemBackground(Sprite background)
        {
            _background.sprite = background;
        }

        private void SetCellIcon(Sprite icon)
        {
            _icon.sprite = icon;
        }

        private void SetCellName(string cellName)
        {
            _name.text = cellName;
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<ICraftable, ItemButton> { }
    }
}
