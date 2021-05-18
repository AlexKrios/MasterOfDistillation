using Assets.Scripts.Ui.Common.ProductMenu;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Craft;
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

#pragma warning disable 649

namespace Assets.Scripts.Ui.Craft.Tab
{
    [UsedImplicitly]
    public class TabsGroup : MonoBehaviour, ITabsGroup
    {
        [Inject] private readonly IUiController _uiController;

        [Inject] private readonly CraftMenuUiFactory.Settings _craftMenuSettings;

        public IProductMenu Menu { get; private set; }
        public List<ITabButton> Tabs { get; set; }

        private ITabButton _activeTab;
        public ITabButton ActiveTab 
        {
            get => _activeTab;
            set
            {
                if (_activeTab == value)
                {
                    return;
                }
                _activeTab.SetInactiveTabImage();
                _activeTab = value;
                _activeTab.SetActiveTabImage();
                Menu.Title.text = _activeTab.Title.ToString();
            }
        }

        [Header("Assets")]
        [SerializeField] private Sprite _bgInactive;
        public Sprite BgInactive => _bgInactive;

        [SerializeField] private Sprite _bgActive;
        public Sprite BgActive => _bgActive;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            Menu = _uiController.FindByPart(_craftMenuSettings.Name).GetComponent<IProductMenu>();
        }

        public void SubscribeTabToList(TabButton button)
        {
            if (Tabs == null)
            {
                Tabs = new List<ITabButton>();
            }

            Tabs.Add(button);

            if (transform.childCount == Tabs.Count)
            {
                _activeTab = Tabs[0];
            }
        }

        public void ClearTabList()
        {
            Tabs.Clear();
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<TabsGroup> { }
    }
}
