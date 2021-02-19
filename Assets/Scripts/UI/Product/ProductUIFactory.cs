using System;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Product
{
    public class ProductUIFactory : IFactory<string, ProductUI> 
    {
        [Inject] private DiContainer _container;
        [Inject] private IUiController _uiController;

        [Inject] private Settings _settings;

        public ProductUI Create(string type)
        {
            var parent = _uiController.Find("Components").transform;
            var productUI = _container.InstantiatePrefabForComponent<ProductUI>(_settings.ProductUIPrefab, parent);
            productUI.name = type;

            _uiController.Add(productUI.name, productUI.gameObject);

            return productUI;
        }

        [Serializable]
        public class Settings
        {
            public GameObject ProductUIPrefab;
        }
    }
}
