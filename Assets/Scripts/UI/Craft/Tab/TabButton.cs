using Assets.Scripts.Objects.Item;
using Assets.Scripts.Objects.Item.Product.Types;
using Assets.Scripts.Ui.Common.ProductMenu;
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#pragma warning disable 649

namespace Assets.Scripts.Ui.Craft.Tab
{
    [UsedImplicitly]
    public class TabButton : MonoBehaviour, ITabButton, IPointerClickHandler
    {
        [SerializeField] private TabsGroup _tabGroup;

        [Header("Assets")]
        [SerializeField] private Image _icon;        
        private RectTransform _position;
        private Canvas _canvas;
        private Image _background;

        [SerializeField] private ItemType _title;
        public ItemType Title => _title;

        [SerializeField] private List<ProductType> _keys;
        public List<ProductType> Keys => _keys;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            _position = GetComponent<RectTransform>();
            _canvas = GetComponent<Canvas>();
            _background = GetComponent<Image>();            
            _tabGroup.SubscribeTabToList(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            var item = _tabGroup.Menu.Items;

            item.ResetMenuItems();
            _tabGroup.ActiveTab = this;
            item.CreateMenuItems();
        }

        public void SetInactiveTabImage()
        {
            SetTabPosition(25);
            SetTabSortOrderOverride(false);
            SetTabBackground(_tabGroup.BgInactive);            
        }

        public void SetActiveTabImage()
        {            
            SetTabPosition(0);
            SetTabSortOrderOverride(true);
            SetTabBackground(_tabGroup.BgActive);            
        }

        private void SetTabIcon(Sprite icon)
        {
            _icon.sprite = icon;
        }

        private void SetTabPosition(float x)
        {
            _position.localPosition = new Vector2(x, _position.localPosition.y);
        }

        private void SetTabSortOrderOverride(bool isActive)
        {
            _canvas.overrideSorting = isActive;
        }

        private void SetTabBackground(Sprite background)
        {
            _background.sprite = background;
        }
    }
}
