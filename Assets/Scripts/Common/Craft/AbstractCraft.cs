using Scripts.Stores;
using UnityEngine;
using Zenject;

namespace Scripts.Common.Craft
{
    public abstract class AbstractCraft : MonoBehaviour, ICraft
    {
        [Inject] protected IProductStore _productStore;
        [Inject] private ICraftController _craftController;

        [Inject] private CraftComponent _craftComponent;

        protected string _productType;
        public string ProductType
        {
            get { return _productType; }
            set { _productType = value; }
        }

        public void CraftComponent()
        {
            _craftController.ActiveStore = _productStore;

            if (!_craftComponent.IsEnoughIngridients())
            {
                return;
            }

            var coroutine = StartCoroutine(_craftComponent.CraftTimer());
            _craftController.Add($"{_productType}Craft", coroutine);
        }

        public void CraftProduct(ProductQuality quality = ProductQuality.Common)
        {
            //var coroutine = StartCoroutine(_craftComponent.Execute(product, _productStore));
            //_craftController.Add($"{_productType}Craft", coroutine);
        }
    }
}
