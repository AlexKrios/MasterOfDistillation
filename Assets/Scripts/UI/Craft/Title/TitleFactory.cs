using Assets.Scripts.UI;
using Assets.Scripts.UI.Craft;
using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.Craft.Title
{
    [UsedImplicitly]
    public class TitleFactory : IFactory<TitleSection>
    {
        [Inject] private readonly CraftMenuUiFactory.Settings _craftMenuSettings;
        [Inject] private readonly IUiController _uiController;

        private readonly DiContainer _container;
        private TitleSection _title;

        public TitleFactory(DiContainer container)
        {
            _container = container;    
        }

        public TitleSection Create()
        {
            var tabsSettings = _craftMenuSettings.TitleSettings;
            var parent = _uiController.FindByPart(_craftMenuSettings.Name).transform;

            _title = _container.InstantiatePrefabForComponent<TitleSection>(tabsSettings.Prefab, parent);
            _title.name = tabsSettings.Name;

            _title.transform.SetSiblingIndex(1);

            return _title;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;
        }
    }
}
