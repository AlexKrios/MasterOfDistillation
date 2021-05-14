using System;
using Assets.Scripts.Scenes.Main.MainCamera.Disable;
using Assets.Scripts.UI.Storage.Item;
using Assets.Scripts.UI.Storage.TypeTab;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Storage
{
    public class StorageMenuUiFactory : IFactory<StorageMenuUi>
    {
        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly IDisable _disable;
        [Inject] private readonly Settings _settings;

        private readonly DiContainer _container;
        private readonly Transform _mainCanvas;
        private StorageMenuUi _storageMenu;

        public StorageMenuUiFactory(DiContainer container, [Inject(Id = "MainCanvas")] RectTransform mainCanvas)
        {
            _container = container;

            _mainCanvas = mainCanvas.gameObject.transform;            
        }

        public StorageMenuUi Create()
        {
            var uiElementSimilar = _uiController.FindByPart(_settings.Name);

            if (uiElementSimilar != null)
            {
                _uiController.Remove(uiElementSimilar);
                _disable.Remove(_settings.Name);
            }

            _storageMenu = _container.InstantiatePrefabForComponent<StorageMenuUi>(_settings.Prefab, _mainCanvas);
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
