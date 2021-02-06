using System;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Money
{
    public class MoneyUIFactory : IFactory<MoneyUI> 
    {
        [Inject] private DiContainer _container;
        [Inject] private IUiController _uiController;

        [Inject] private Settings _settings;

        private Transform _mainCanvas;

        public MoneyUIFactory([Inject(Id = "MainCanvas")] RectTransform mainCanvas)
        {
            _mainCanvas = mainCanvas.gameObject.transform;
        }

        public MoneyUI Create()
        {
            var moneyUI = _container.InstantiatePrefabForComponent<MoneyUI>(_settings.MoneyUIPrefab, _mainCanvas);
            moneyUI.name = "Money";

            _uiController.Add(moneyUI.name, moneyUI.gameObject);

            return moneyUI;
        }

        [Serializable]
        public class Settings
        {
            public GameObject MoneyUIPrefab;
        }
    }
}
