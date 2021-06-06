using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.FullMenu.Common.Model
{
    [UsedImplicitly]
    public class ModelGroupFactory : IFactory<ModelGroup> 
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly Settings _settings;

        [Inject] private readonly IUiController _uiController;

        public ModelGroup Create()
        {
            var parent = _uiController.FindByPart("Menu").transform;

            var model = _container.InstantiatePrefabForComponent<ModelGroup>(_settings.Prefab, parent);
            model.name = _settings.Name;

            var rectTransform = model.gameObject.GetComponent<RectTransform>();
            rectTransform.SetParent(parent);

            return model;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;
        }
    }
}
