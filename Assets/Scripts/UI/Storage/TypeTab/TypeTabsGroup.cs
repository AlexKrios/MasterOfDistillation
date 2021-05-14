using System.Collections.Generic;
using UnityEngine;
using Zenject;
#pragma warning disable 649

namespace Assets.Scripts.UI.Storage.TypeTab
{
    public class TypeTabsGroup : MonoBehaviour
    {
        [Inject] private IUiController _uiController;

        public StorageMenuUi Menu { get; private set; }

        public List<TypeTabButton> Tabs { get; private set; }

        private TypeTabButton _activeTab;
        public TypeTabButton ActiveTab 
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
            Menu = _uiController.FindByPart("StorageMenu").GetComponent<StorageMenuUi>();
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
