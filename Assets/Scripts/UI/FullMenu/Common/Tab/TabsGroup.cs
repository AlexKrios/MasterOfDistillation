using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

// ReSharper disable UnusedMember.Local

#pragma warning disable 649

namespace Assets.Scripts.Ui.FullMenu.Common.Tab
{
    [UsedImplicitly]
    public class TabsGroup : MonoBehaviour, ITabsGroup
    {
        #region Links

        [Inject] private readonly IUiController _uiController;

        private IFullMenu _fullMenu;
        private List<ITabButton> _tabs;

        public ITabButton ActiveTab
        {
            get => _fullMenu.ActiveTab;
            set => _fullMenu.ActiveTab = value;
        }

        #endregion

        #region Assets

        [Header("Assets")]
        [SerializeField] private Color _bgInactive;
        public Color BgInactive => _bgInactive;

        [SerializeField] private Color _bgActive;
        public Color BgActive => _bgActive;

        #endregion

        private void Awake()
        {
            _fullMenu = _uiController.FindByPart("Menu").GetComponent<IFullMenu>();
            _fullMenu.Tabs = this;
        }

        public void SubscribeTabToList(ITabButton button)
        {
            if (_tabs == null)
            {
                _tabs = new List<ITabButton>();
                SetInitTab(button);
            }

            _tabs.Add(button);
        }

        private void SetInitTab(ITabButton button)
        {
            ActiveTab = button;
            ActiveTab.SetActiveTabImage();
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<TabsGroup> { }
    }
}
