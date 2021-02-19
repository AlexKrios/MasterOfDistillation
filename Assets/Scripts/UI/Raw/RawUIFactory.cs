using System;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Raw
{
    public class RawUIFactory : IFactory<RawUI> 
    {
        [Inject] private DiContainer _container;
        [Inject] private IUiController _uiController;

        [Inject] private Settings _settings;

        private Transform _mainCanvas;

        public RawUIFactory([Inject(Id = "MainCanvas")] RectTransform mainCanvas)
        {
            _mainCanvas = mainCanvas.gameObject.transform;
        }

        public RawUI Create()
        {
            var rawUI = _container.InstantiatePrefabForComponent<RawUI>(_settings.RawUIPrefab, _mainCanvas);
            rawUI.name = "Raw";

            _uiController.Add(rawUI.name, rawUI.gameObject);

            return rawUI;
        }

        [Serializable]
        public class Settings
        {
            public GameObject RawUIPrefab;
        }
    }
}
