using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Money
{
    public class MoneyUiFactory : IFactory<MoneyUi> 
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly IUiController _uiController;

        [Inject] private readonly Settings _settings;

        private readonly Transform _mainCanvas;

        public MoneyUiFactory([Inject(Id = "MainCanvas")] RectTransform mainCanvas)
        {
            _mainCanvas = mainCanvas.gameObject.transform;
        }

        public MoneyUi Create()
        {
            var moneyUi = _container.InstantiatePrefabForComponent<MoneyUi>(_settings.MoneyUiPrefab, _mainCanvas);
            moneyUi.name = "Money";

            _uiController.Add(moneyUi.name, moneyUi.gameObject);

            return moneyUi;
        }

        [Serializable]
        public class Settings
        {
            public GameObject MoneyUiPrefab;
        }
    }
}
