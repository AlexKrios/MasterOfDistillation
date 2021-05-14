using System.Collections.Generic;
using Scripts.Objects.Product;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
#pragma warning disable 649

namespace Assets.Scripts.UI.Storage.TypeTab
{
    public class TypeTabButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TypeTabsGroup _tabGroup;

        [Header("Assets")]
        [SerializeField] private Image _icon;        
        private RectTransform _position;
        private Canvas _canvas;
        private Image _background;

        [SerializeField] private List<ProductSubType> _keys;
        public List<ProductSubType> Keys => _keys;

        [SerializeField] private ProductType _title;
        public ProductType Title => _title;

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
            var item = _tabGroup.Menu.ItemsGroup;

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

        public void SetTabIcon(Sprite icon)
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

        public void SetTabBackground(Sprite background)
        {
            _background.sprite = background;
        }
    }
}
