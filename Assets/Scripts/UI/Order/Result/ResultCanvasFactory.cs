using Assets.Scripts.MainCamera.Disable;
using Assets.Scripts.Objects.Item.Craft;
using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.Order.Result
{
    [UsedImplicitly]
    public class ResultCanvasFactory : IFactory<CraftObject, ResultCanvas> 
    {
        [Inject] private readonly DiContainer _container;

        [Inject] private readonly ResultModel.Factory _resultModelFactory;
        [Inject] private readonly Settings _settings;
        
        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly IDisable _disable;

        public ResultCanvas Create(CraftObject obj)
        {
            var result = _container.InstantiatePrefabForComponent<ResultCanvas>(_settings.Prefab);
            result.name = _settings.Name;

            var model = _resultModelFactory.Create(obj.Item.Model);
            model.SetInitTransform(result.transform);

            _disable.Add(DisableType.Camera);

            _uiController.Add(_settings.Name, result.gameObject);

            return result;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;

            public float FadeTime;
        }
    }
}
