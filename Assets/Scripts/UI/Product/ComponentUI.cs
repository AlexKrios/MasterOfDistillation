using System;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Product
{
    public class ComponentUI : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<ComponentUI> { }
    }

    public class ComponentUIFactory : IFactory<ComponentUI>
    {
        [Inject] private DiContainer _container;
        [Inject] private IUiController _uiController;

        [Inject] private Settings _settings;

        private Transform _mainCanvas;

        public ComponentUIFactory([Inject(Id = "MainCanvas")] RectTransform mainCanvas)
        {
            _mainCanvas = mainCanvas.gameObject.transform;
        }

        public ComponentUI Create()
        {
            var componentUI = _container.InstantiatePrefabForComponent<ComponentUI>(_settings.ComponentUIPrefab, _mainCanvas);
            componentUI.name = "Components";

            _uiController.Add(componentUI.name, componentUI.gameObject);

            return componentUI;
        }

        [Serializable]
        public class Settings
        {
            public GameObject ComponentUIPrefab;
        }
    }
}
