using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.FullMenu.Common.Tab
{
    [UsedImplicitly]
    public class TabsGroupFactory : IFactory<TabsGroup>
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly Settings _settings;

        [Inject] private readonly IUiController _uiController;

        public TabsGroup Create()
        {
            var parent = _uiController.FindByPart("Menu").transform;

            var tab = _container.InstantiatePrefabForComponent<TabsGroup>(_settings.Prefab, parent);
            tab.name = _settings.Name;

            tab.transform.SetSiblingIndex(1);

            return tab;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;
        }
    }
}
