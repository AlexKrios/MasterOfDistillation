using Scripts.Scenes.Main.MainCamera;
using Scripts.UI.Craft.Item;
using Scripts.UI.Craft.TypeTab;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Craft
{
    public class CraftMenuUIFactory : IFactory<CraftMenu>
    {
        [Inject] private IUiController _uiController;
        [Inject] private IDisable _disable;
        [Inject] private Settings _settings;

        private DiContainer _container;
        private CraftMenu _craftMenu;
        private Transform _mainCanvas;

        public CraftMenuUIFactory(DiContainer container, [Inject(Id = "MainCanvas")] RectTransform mainCanvas)
        {
            _container = container;

            _mainCanvas = mainCanvas.gameObject.transform;
        }

        public CraftMenu Create()
        {
            var uiElementSimilar = _uiController.FindByPart(_settings.Name);

            if (uiElementSimilar != null)
            {
                _uiController.Remove(uiElementSimilar);
                _disable.Remove(_settings.Name);
            }

            _craftMenu = _container.InstantiatePrefabForComponent<CraftMenu>(_settings.Prefab, _mainCanvas);
            _craftMenu.name = _settings.Name;

            _uiController.Add(_craftMenu.name, _craftMenu.gameObject);
            _disable.Add(_settings.Name);

            return _craftMenu;
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
