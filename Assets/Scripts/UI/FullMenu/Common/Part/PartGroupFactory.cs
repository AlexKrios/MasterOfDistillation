using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.FullMenu.Common.Part
{
    [UsedImplicitly]
    public class PartGroupFactory : IFactory<PartGroup>
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly Settings _settings;

        [Inject] private readonly IUiController _uiController;

        public PartGroup Create()
        {
            var parent = _uiController.FindByPart("Menu").GetComponent<IFullMenu>().Product.Transform;

            var partGroup = _container.InstantiatePrefabForComponent<PartGroup>(_settings.Prefab, parent);
            partGroup.name = _settings.Name;

            partGroup.transform.SetSiblingIndex(1);

            return partGroup;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;
        }
    }
}
