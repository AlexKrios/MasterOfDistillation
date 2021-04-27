using Scripts.Scenes.Main.MainCamera;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop.Craft
{
    public class CraftMenuUIFactory : IFactory<CraftMenuUI>
    {
        [Inject] private IUiController _uiController;
        [Inject] private IDisable _disable;
        [Inject] private Settings _settings;

        private DiContainer _container;
        private CraftMenuUI _craftMenu;
        private Transform _mainCanvas;                       

        public CraftMenuUIFactory(DiContainer container, [Inject(Id = "MainCanvas")] RectTransform mainCanvas)
        {
            _container = container;

            _mainCanvas = mainCanvas.gameObject.transform;            
        }

        public CraftMenuUI Create()
        {
            var uiElementSimilar = _uiController.FindByPart(_settings.Name);

            if (uiElementSimilar != null)
            {
                _uiController.Remove(uiElementSimilar);
                _disable.Remove(_settings.Name);
            }

            _craftMenu = _container.InstantiatePrefabForComponent<CraftMenuUI>(_settings.Prefab, _mainCanvas);
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

            public int RowCount;
            public int Padding;
            public int Height;
        }
    }
}
