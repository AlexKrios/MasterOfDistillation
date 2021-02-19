using Scripts.Stores;
using UnityEngine;
using Zenject;

namespace Scripts.Common.Craft
{
    public abstract class AbstractCraft : MonoBehaviour
    {
        [Inject] protected IProductStore _productStore;
        [Inject] private ICraftController _craftController;

        [Inject] private CraftComponent _craftComponent;

        protected string _productType;
        protected string ProductType
        {
            get { return _productType; }
            set { _productType = value; }
        }

        public void CraftComponent(ProductQuality quality = ProductQuality.Common)
        {
            var coroutine = StartCoroutine(_craftComponent.Execute(quality, _productStore));
            _craftController.Add($"{_productType}Craft", coroutine);
        }

        public void CraftProduct(ProductQuality quality = ProductQuality.Common)
        {
            var coroutine = StartCoroutine(_craftComponent.Execute(quality, _productStore));
            _craftController.Add($"{_productType}Craft", coroutine);
        }
    }
}
