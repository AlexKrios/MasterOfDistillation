﻿using System;
using UnityEngine;
using Zenject;
// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.Money
{
    public class MoneyUiFactory : IFactory<MoneyUi> 
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly Settings _settings;

        [Inject] private readonly IUiController _uiController;

        [Inject(Id = "MainCanvas")] private readonly RectTransform _mainCanvas;

        public MoneyUi Create()
        {
            var moneyUi = _container.InstantiatePrefabForComponent<MoneyUi>(_settings.Prefab, _mainCanvas);
            moneyUi.name = _settings.Name;

            _uiController.Add(moneyUi.name, moneyUi.gameObject);

            return moneyUi;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;
        }
    }
}
