using Assets.Scripts.Objects.Item;
using Assets.Scripts.Ui.FullMenu.Common;
using Assets.Scripts.Ui.FullMenu.Common.Item;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

// ReSharper disable UnusedMember.Local

#pragma warning disable 649

namespace Assets.Scripts.Ui.FullMenu.Storage.Item
{
    [UsedImplicitly]
    public class ItemButton : MonoBehaviour, IItemButton, IPointerClickHandler
    {
        #region Links

        [Inject] private readonly StorageMenuFactory.Settings _storageMenuSettings;

        [Inject] private readonly IUiController _uiController;

        private IFullMenu _fullMenu;
        private IItemButton ActiveItem
        {
            get => _fullMenu.ActiveItem;
            set => _fullMenu.ActiveItem = value;
        }

        #endregion

        #region Assets

        private Image _background;

        [Header("Assets")]
        [SerializeField] private Image _icon;
        [SerializeField] private Text _name;
        [SerializeField] private Text _level;

        [Header("Background assets")]
        [SerializeField] private Sprite _bgInactive;
        [SerializeField] private Sprite _bgActive;

        #endregion

        public ICraftable Product { get; private set; }

        private void Awake()
        {
            _fullMenu = _uiController.Find(_storageMenuSettings.Name).GetComponent<StorageMenu>();

            _background = GetComponent<Image>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if ((ItemButton)ActiveItem == this) 
                return;

            ActiveItem?.SetItemInactive();
            ActiveItem = this;
            ActiveItem.SetItemActive();

            _fullMenu.Product.SetProductInfo();
            _fullMenu.Quality.ResetQuality();
            _fullMenu.Parts.SetPartsInfo();
            _fullMenu.Model.CreateModel();
        }

        public void SetCellInfo(ICraftable product)
        {
            Product = product;
            Product.GameObject = gameObject;

            SetCellIcon(product.Icon);
            SetCellName(product.Name);
            SetCellLevel(product.Level);
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

        private void SetCellName(string cellName)
        {
            _name.text = cellName;
        }

        private void SetCellLevel(int level)
        {
            _level.text = level.ToString();
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<ICraftable, ItemButton> { }
    }
}
