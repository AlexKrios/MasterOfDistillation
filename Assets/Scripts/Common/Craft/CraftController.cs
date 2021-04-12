using Scripts.UI.Workshop.Craft;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Common.Craft
{
    public class CraftController : ICraftController
    {
        [Inject] ICraftMenuUIController _craftMenuUIController;

        private Dictionary<string, Coroutine> _craftList = new Dictionary<string, Coroutine>();

        private ProductData _activeProduct;
        public ProductData ActiveProduct
        {
            get { return _activeProduct; }
            set { _activeProduct = value; }
        }

        private ProductQuality _productQuality;
        public ProductQuality ProductQuality
        {
            get { return _productQuality; }
            set 
            {                
                _productQuality = value;
                _craftMenuUIController.OnSetQualityIcon.Invoke();
            }
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
