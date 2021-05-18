﻿using Assets.Scripts.Objects.Item;
using Assets.Scripts.Ui.Common.ProductMenu;
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
        [Inject] private readonly IUiController _uiController;

        [Inject] private readonly CraftMenuUiFactory.Settings _craftMenuSettings;

        private IItemsGroup _itemGroup;

        [Header("Product cell info")]
        [SerializeField] private Image _background;
        [SerializeField] private Image _icon;
        [SerializeField] private Text _name;

        [Header("Assets")]
        [SerializeField] private Sprite _bgInactive;
        public Sprite BgInactive => _bgInactive;

        [SerializeField] private Sprite _bgActive;
        public Sprite BgActive => _bgActive;
        public ICraftable Product { get; set; }

        // ReSharper disable once UnusedMember.Local
        private void Start() 
        {
            _itemGroup = _uiController.FindByPart(_craftMenuSettings.Name).GetComponent<IProductMenu>().Items;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _itemGroup.ActiveItem = this;
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
