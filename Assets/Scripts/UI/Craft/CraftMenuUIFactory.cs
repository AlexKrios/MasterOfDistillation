using Assets.Scripts.Scenes.Main.MainCamera.Disable;
using Assets.Scripts.Ui.Craft.Tab;
using Assets.Scripts.Ui.Craft.Title;
using Assets.Scripts.UI.Craft.Item;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Craft
{
    public class CraftMenuUiFactory : IFactory<CraftMenu>
    {
        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly IDisable _disable;
        [Inject] private readonly Settings _settings;

        private readonly DiContainer _container;
        private readonly Transform _mainCanvas;
        private CraftMenu _craftMenu;

        public CraftMenuUiFactory(DiContainer container, [Inject(Id = "MainCanvas")] RectTransform mainCanvas)
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

            public TitleFactory.Settings TitleSettings;
            public TabFactory.Settings TabsSettings;
            public ItemsGroupFactory.Settings ItemsGroupSettings;
            public ItemButtonFactory.Settings ItemButtonSettings;
        }
    }
}
