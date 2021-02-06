using System;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Level
{
    public class LevelUIFactory : IFactory<LevelUI> 
    {
        [Inject] private DiContainer _container;
        [Inject] private IUiController _uiController;

        [Inject] private Settings _settings;

        private Transform _mainCanvas;

        public LevelUIFactory([Inject(Id = "MainCanvas")] RectTransform mainCanvas)
        {
            _mainCanvas = mainCanvas.gameObject.transform;
        }

        public LevelUI Create()
        {
            var levelUI = _container.InstantiatePrefabForComponent<LevelUI>(_settings.LevelUIPrefab, _mainCanvas);
            levelUI.name = "Level";

            _uiController.Add(levelUI.name, levelUI.gameObject);

            return levelUI;
        }

        [Serializable]
        public class Settings
        {
            public GameObject LevelUIPrefab;
        }
    }
}
