using Scripts.Objects.Product;
using Scripts.Stores;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Common.Craft
{
    public class CraftController : ICraftController
    {
        private Dictionary<string, Coroutine> _craftList = new Dictionary<string, Coroutine>();

        private ProductObject _activeProduct;
        public ProductObject ActiveProduct
        {
            get { return _activeProduct; }
            set { _activeProduct = value; }
        }
        private IProductStore _activeStore;
        public IProductStore ActiveStore
        {
            get { return _activeStore; }
            set { _activeStore = value; }
        }

        public void Add(string key, Coroutine coroutine)
        {
            _craftList.Add(key, coroutine);
        }

        public Coroutine FindByKey(string key)
        {
            return _craftList[key];
        }

        public void Remove(string key)
        {
            _craftList.Remove(key);
        }
    }
}
