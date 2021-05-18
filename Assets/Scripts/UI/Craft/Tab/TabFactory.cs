using Assets.Scripts.UI;
using Assets.Scripts.UI.Craft;
using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.Craft.Tab
{
    [UsedImplicitly]
    public class TabFactory : IFactory<TabsGroup>
    {
        [Inject] private readonly IUiController _uiController;

        [Inject] private readonly CraftMenuUiFactory.Settings _craftMenuSettings;

        private readonly DiContainer _container;
        private TabsGroup _tab;

        public TabFactory(DiContainer container)
        {
            _container = container;    
        }

        public TabsGroup Create()
        {
            var tabsSettings = _craftMenuSettings.TabsSettings;
            var parent = _uiController.FindByPart(_craftMenuSettings.Name).transform;

            _tab = _container.InstantiatePrefabForComponent<TabsGroup>(tabsSettings.Prefab, parent);
            _tab.name = tabsSettings.Name;

            _tab.transform.SetSiblingIndex(1);

            return _tab;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;
        }
    }
}
