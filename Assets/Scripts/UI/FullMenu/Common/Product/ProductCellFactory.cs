using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.FullMenu.Common.Product
{
    [UsedImplicitly]
    public class ProductCellFactory : IFactory<ProductCell>
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly Settings _settings;

        [Inject] private readonly IUiController _uiController;

        public ProductCell Create()
        {
            var parent = _uiController.FindByPart("Menu").transform;

            var product = _container.InstantiatePrefabForComponent<ProductCell>(_settings.Prefab, parent);
            product.name = _settings.Name;

            product.transform.SetSiblingIndex(3);

            return product;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;
        }
    }
}
