using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.FullMenu.Common.Part
{
    [UsedImplicitly]
    public class PartCellFactory : IFactory<PartCell>
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly Settings _settings;

        [Inject] private readonly IUiController _uiController;

        public PartCell Create()
        {
            var parent = _uiController.FindByPart("Menu").GetComponent<IFullMenu>().Product.Transform;

            var part = _container.InstantiatePrefabForComponent<PartCell>(_settings.Prefab, parent);

            return part;
        }

        [Serializable]
        public class Settings
        {
            public GameObject Prefab;
        }
    }
}
