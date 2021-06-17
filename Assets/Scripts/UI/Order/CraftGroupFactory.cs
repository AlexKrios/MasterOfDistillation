using Assets.Scripts.Ui.Order.Cell;
using Assets.Scripts.Ui.Order.Plus;
using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.Order
{
    [UsedImplicitly]
    public class CraftGroupFactory : IFactory<CraftGroup> 
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly Settings _settings;

        [Inject] private readonly IUiController _uiController;
        private readonly Transform _mainCanvas;

        public CraftGroupFactory([Inject(Id = "MainCanvas")] RectTransform mainCanvas)
        {
            _mainCanvas = mainCanvas.gameObject.transform;
        }

        public CraftGroup Create()
        {
            var group = new GameObject(_settings.Name);
            group.transform.SetParent(_mainCanvas);

            var result = _container.InstantiateComponent<CraftGroup>(group);

            var rectTransform = result.gameObject.AddComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(25, 25, 0);
            rectTransform.localScale = new Vector3(1, 1, 1);
            rectTransform.sizeDelta = new Vector2(675, 150);
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.pivot = new Vector2(0, 0);

            var horizontalLayoutGroup = result.gameObject.AddComponent<HorizontalLayoutGroup>();
            horizontalLayoutGroup.childControlHeight = false;
            horizontalLayoutGroup.childControlWidth = false;
            horizontalLayoutGroup.spacing = _settings.Spacing;
            horizontalLayoutGroup.childAlignment = TextAnchor.MiddleCenter;

            _uiController.Add(_settings.Name, result.gameObject);

            return result;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public int Spacing;

            public CraftCellFactory.Settings CraftCellSettings;
            public CraftPlusCellFactory.Settings CraftPlusCellSettings;
        }
    }
}
