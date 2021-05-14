using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Level
{
    public class LevelUiFactory : IFactory<LevelUi> 
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly IUiController _uiController;

        [Inject] private readonly Settings _settings;

        private readonly Transform _mainCanvas;

        public LevelUiFactory([Inject(Id = "MainCanvas")] RectTransform mainCanvas)
        {
            _mainCanvas = mainCanvas.gameObject.transform;
        }

        public LevelUi Create()
        {
            var levelUi = _container.InstantiatePrefabForComponent<LevelUi>(_settings.LevelUiPrefab, _mainCanvas);
            levelUi.name = "Level";

            _uiController.Add(levelUi.name, levelUi.gameObject);

            return levelUi;
        }

        [Serializable]
        public class Settings
        {
            public GameObject LevelUiPrefab;
        }
    }
}
