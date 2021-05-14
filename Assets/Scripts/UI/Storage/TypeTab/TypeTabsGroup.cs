using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop.Storage.TypeTab
{
    public class TypeTabsGroup : MonoBehaviour
    {
        [Inject] private IUiController _uiController;

        private StorageMenuUI _menu;
        public StorageMenuUI Menu { get => _menu; }

        private List<TypeTabButton> _tabs;
        public List<TypeTabButton> Tabs { get => _tabs; }

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
                    _menu.Title.text = _activeTab.Title.ToString();
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
            _menu = _uiController.FindByPart("StorageMenu").GetComponent<StorageMenuUI>();
        }

        public void SubscribeTabToList(TypeTabButton button)
        {
            if (_tabs == null)
            {
                _tabs = new List<TypeTabButton>();
            }

            _tabs.Add(button);

            if (transform.childCount == _tabs.Count)
            {
                _activeTab = _tabs[0];
            }
        }

        public void ClearTabList()
        {
            _tabs.Clear();
        }

        public class Factory : PlaceholderFactory<TypeTabsGroup> { }
    }
}
