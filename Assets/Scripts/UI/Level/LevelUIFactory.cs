using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Ui.Level
{
    public class LevelUiFactory : IFactory<LevelUi>
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly Settings _settings;
        
        [Inject] private readonly IUiController _uiController;

        [Inject(Id = "MainCanvas")] private readonly RectTransform _mainCanvas;

        public LevelUi Create()
        {
            var levelUi = _container.InstantiatePrefabForComponent<LevelUi>(_settings.Prefab, _mainCanvas);
            levelUi.name = _settings.Name;

            _uiController.Add(levelUi.name, levelUi.gameObject);

            return levelUi;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;
        }
    }
}
