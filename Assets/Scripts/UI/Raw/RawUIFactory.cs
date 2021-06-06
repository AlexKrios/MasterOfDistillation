using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Ui.Raw
{
    public class RawUiFactory : IFactory<RawUi> 
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly IUiController _uiController;

        [Inject] private readonly Settings _settings;

        private readonly Transform _mainCanvas;

        public RawUiFactory([Inject(Id = "MainCanvas")] RectTransform mainCanvas)
        {
            _mainCanvas = mainCanvas.gameObject.transform;
        }

        public RawUi Create()
        {
            var rawUi = _container.InstantiatePrefabForComponent<RawUi>(_settings.Prefab, _mainCanvas);
            rawUi.name = _settings.Name;

            _uiController.Add(rawUi.name, rawUi.gameObject);

            return rawUi;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;
        }
    }
}
