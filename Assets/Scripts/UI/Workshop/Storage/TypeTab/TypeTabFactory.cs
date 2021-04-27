using System;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop.Storage.TypeTab
{
    public class TypeTabFactory : IFactory<TypeTabsGroup>
    {
        [Inject] private IUiController _uiController;
        [Inject] private Settings _settings;

        private DiContainer _container;
        private TypeTabsGroup _typeTab;

        public TypeTabFactory(DiContainer container)
        {
            _container = container;    
        }

        public TypeTabsGroup Create()
        {
            var parent = _uiController.FindByPart("StorageMenu").transform;

            _typeTab = _container.InstantiatePrefabForComponent<TypeTabsGroup>(_settings.Prefab, parent);
            _typeTab.name = _settings.Name;

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
