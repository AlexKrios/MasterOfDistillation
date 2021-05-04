using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop.Craft.TypeTab
{
    public class TypeTabsGroup : MonoBehaviour
    {
        [Inject] private IUiController _uiController;
        [Inject] private CraftMenuUIFactory.Settings _menuSettings;

        public CraftMenuUI Menu { get; private set; }
        public List<TypeTabButton> Tabs { get; private set; }

        private TypeTabButton _activeTab;
        public TypeTabButton ActiveTab 
        {
            get { return _activeTab; }
            set 
            {
                if (_activeTab != value)
                {
                    _activeTab.SetInactiveTabImage();
                    _activeTab = value;
                    _activeTab.SetActiveTabImage();
                    Menu.Title.text = _activeTab.Title.ToString();
                }                
            }
        }

        [Header("Assets")]
        [SerializeField] private Sprite _bgInactive;
        public Sprite BgInactive { get => _bgInactive; }

        [SerializeField] private Sprite _bgActive;
        public Sprite BgActive { get => _bgActive; }

        private void Start()
        {
            Menu = _uiController.FindByPart(_menuSettings.Name).GetComponent<CraftMenuUI>();
        }

        public void SubscribeTabToList(TypeTabButton button)
        {
            if (Tabs == null)
            {
                Tabs = new List<TypeTabButton>();
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

        public class Factory : PlaceholderFactory<TypeTabsGroup> { }
    }
}
