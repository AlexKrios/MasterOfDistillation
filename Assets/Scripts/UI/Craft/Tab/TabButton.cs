using Assets.Scripts.Objects.Item;
using Assets.Scripts.Objects.Item.Product.Types;
using Assets.Scripts.Ui.Craft.Title;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Craft;
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

#pragma warning disable 649

namespace Assets.Scripts.Ui.Craft.Tab
{
    [UsedImplicitly]
    public class TabButton : MonoBehaviour, ITabButton, IPointerClickHandler
    {
        #region Links

        [Inject] private readonly CraftMenuUiFactory.Settings _craftMenuSettings;
        [Inject] private readonly IUiController _uiController;

        private ICraftMenu _menu;
        private ITabsGroup _tabGroup;
        private ITitleSection _menuTitle;
        private ITabButton ActiveTab
        {
            get => _tabGroup.ActiveTab;
            set => _tabGroup.ActiveTab = value;
        }

        [SerializeField] private ItemType _title;
        [SerializeField] private List<ProductType> _keys;
        public List<ProductType> Keys => _keys;

        #endregion

        #region Assets

        [Header("Assets")]
        private RectTransform _position;
        private Canvas _canvas;
        private Image _background;

        #endregion

        // ReSharper disable once UnusedMember.Local
        private void Awake()
        {
            _menu = _uiController.FindByPart(_craftMenuSettings.Name).GetComponent<ICraftMenu>();
        }

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            _menuTitle = _menu.Title;
            _tabGroup = _menu.Tabs;

            _position = GetComponent<RectTransform>();
            _canvas = GetComponent<Canvas>();
            _background = GetComponent<Image>();

            _tabGroup.SubscribeTabToList(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if ((TabButton)ActiveTab == this)
            {
                return;
            }

            ActiveTab?.SetInactiveTabImage();
            ActiveTab = this;
            ActiveTab.SetActiveTabImage();

            _menuTitle.Text = _title.ToString();
        }

        public void SetInactiveTabImage()
        {
            SetTabPosition(25);
            SetTabSortOrderOverride(false);
            SetTabBackground(_tabGroup.BgInactive);

            _menu.Items.ResetMenuItems();
        }

        public void SetActiveTabImage()
        {            
            SetTabPosition(0);
            SetTabSortOrderOverride(true);
            SetTabBackground(_tabGroup.BgActive);

            _menu.Items.CreateMenuItems();
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
