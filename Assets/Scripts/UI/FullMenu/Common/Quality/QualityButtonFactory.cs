using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.FullMenu.Common.Quality
{
    [UsedImplicitly]
    public class QualityButtonFactory : IFactory<QualityButton>
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly Settings _settings;

        [Inject] private readonly IUiController _uiController;

        public QualityButton Create()
        {
            var parent = _uiController.FindByPart("Menu").GetComponent<IFullMenu>().Product.Transform;

            var button = _container.InstantiatePrefabForComponent<QualityButton>(_settings.Prefab, parent);
            button.name = _settings.Name;

            button.transform.SetSiblingIndex(3);

            return button;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;
        }
    }
}
