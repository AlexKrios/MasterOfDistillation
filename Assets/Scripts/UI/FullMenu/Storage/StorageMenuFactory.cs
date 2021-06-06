using Assets.Scripts.MainCamera.Disable;
using Assets.Scripts.Ui.FullMenu.Storage.Item;
using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.FullMenu.Storage
{
    [UsedImplicitly]
    public class StorageMenuFactory : IFactory<StorageMenu>
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly Settings _settings;

        [Inject] private readonly IDisable _disable;

        [Inject(Id = "MainCanvas")] private readonly RectTransform _mainCanvas;
        [Inject(Id = "MenuCanvas")] private readonly RectTransform _menuCanvas;

        public StorageMenu Create()
        {
            _mainCanvas.gameObject.SetActive(false);

            _disable.Add(DisableType.Camera);

            return _container.InstantiatePrefabForComponent<StorageMenu>(_settings.Prefab, _menuCanvas);
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;

            public ItemsGroupFactory.Settings ItemsGroupSettings;
            public ItemButtonFactory.Settings ItemButtonSettings;
        }
    }
}
