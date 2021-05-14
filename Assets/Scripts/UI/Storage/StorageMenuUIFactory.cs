using Scripts.Scenes.Main.MainCamera;
using Scripts.UI.Workshop.Storage.Item;
using Scripts.UI.Workshop.Storage.TypeTab;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop.Storage
{
    public class StorageMenuUIFactory : IFactory<StorageMenuUI>
    {
        [Inject] private IUiController _uiController;
        [Inject] private IDisable _disable;
        [Inject] private Settings _settings;

        private DiContainer _container;
        private StorageMenuUI _storageMenu;
        private Transform _mainCanvas;                       

        public StorageMenuUIFactory(DiContainer container, [Inject(Id = "MainCanvas")] RectTransform mainCanvas)
        {
            _container = container;

            _mainCanvas = mainCanvas.gameObject.transform;            
        }

        public StorageMenuUI Create()
        {
            var uiElementSimilar = _uiController.FindByPart(_settings.Name);

            if (uiElementSimilar != null)
            {
                _uiController.Remove(uiElementSimilar);
                _disable.Remove(_settings.Name);
            }

            _storageMenu = _container.InstantiatePrefabForComponent<StorageMenuUI>(_settings.Prefab, _mainCanvas);
            _storageMenu.name = _settings.Name;

            _uiController.Add(_storageMenu.name, _storageMenu.gameObject);
            _disable.Add(_settings.Name);

            return _storageMenu;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;

            public TypeTabFactory.Settings TabsSettings;
            public ItemsGroupFactory.Settings ItemsGroupSettings;
            public ItemButtonFactory.Settings ItemButtonSettings;
        }
    }
}
