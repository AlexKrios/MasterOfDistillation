using Assets.Scripts.Objects.Item;
using Assets.Scripts.Objects.Item.Product.Types;
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;
// ReSharper disable UnusedMember.Local

#pragma warning disable 649

namespace Assets.Scripts.Ui.FullMenu.Common.Tab
{
    [UsedImplicitly]
    public class TabButton : MonoBehaviour, ITabButton, IPointerClickHandler
    {
        #region Links

        [Inject] private readonly IUiController _uiController;

        private IFullMenu _fullMenu;
        private ITabsGroup _tabGroup;
        private ITabButton ActiveTab
        {
            get => _tabGroup.ActiveTab;
            set => _tabGroup.ActiveTab = value;
        }

        [SerializeField] private ItemType _title;
        public ItemType Title => _title;

        [SerializeField] private List<ProductType> _keys;
        public List<ProductType> Keys => _keys;

        #endregion

        #region Assets

        [Header("Assets")]
        private Image _background;

        #endregion

        private void Awake()
        {
            _fullMenu = _uiController.FindByPart("Menu").GetComponent<IFullMenu>();
            _tabGroup = _fullMenu.Tabs;

            _background = GetComponent<Image>();

            _tabGroup.SubscribeTabToList(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if ((TabButton)ActiveTab == this)
                return;

            ActiveTab?.SetInactiveTabImage();
            ActiveTab = this;
            ActiveTab.SetActiveTabImage();

            _fullMenu.Items.CreateItems();
            _fullMenu.Items.SetInitItem();
            _fullMenu.Product.SetProductInfo();
            _fullMenu.Quality.ResetQuality();
            _fullMenu.Parts.SetPartsInfo();
            _fullMenu.Model.CreateModel();
        }

        public void SetInactiveTabImage()
        {
            SetTabBackground(_tabGroup.BgInactive);
        }

        public void SetActiveTabImage()
        {            
            SetTabBackground(_tabGroup.BgActive);
        }

        private void SetTabBackground(Color color)
        {
            _background.color = color;
        }
    }
}
