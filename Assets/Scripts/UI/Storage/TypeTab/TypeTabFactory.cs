using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Storage.TypeTab
{
    public class TypeTabFactory : IFactory<TypeTabsGroup>
    {
        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly StorageMenuUiFactory.Settings _menuSettings;

        private readonly DiContainer _container;
        private TypeTabsGroup _typeTab;

        public TypeTabFactory(DiContainer container)
        {
            _container = container;    
        }

        public TypeTabsGroup Create()
        {
            var tabsSettings = _menuSettings.TabsSettings;
            var parent = _uiController.FindByPart(_menuSettings.Name).transform;

            _typeTab = _container.InstantiatePrefabForComponent<TypeTabsGroup>(tabsSettings.Prefab, parent);
            _typeTab.name = tabsSettings.Name;

            _typeTab.transform.SetSiblingIndex(1);

            return _typeTab;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;
        }
    }
}
