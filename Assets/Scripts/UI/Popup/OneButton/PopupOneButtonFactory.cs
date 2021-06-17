using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.Popup.OneButton
{
    [UsedImplicitly]
    public class PopupOneButtonFactory
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly Settings _settings;

        [Inject(Id = "PopupCanvas")] private readonly RectTransform _popupCanvas;

        public PopupBase Create<T>() where T : PopupBase
        {
            var popup = _container.InstantiatePrefabForComponent<PopupOneButton>(_settings.Prefab, _popupCanvas.transform);
            _container.InstantiateComponent<T>(popup.gameObject);

            return popup.GetComponent<T>();
        }

        [Serializable]
        public class Settings
        {
            public GameObject Prefab;
        }
    }
}
