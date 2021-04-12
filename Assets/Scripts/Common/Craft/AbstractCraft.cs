using Scripts.Common.Craft.Action;
using Scripts.Stores;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Common.Craft
{
    public abstract class AbstractCraft : MonoBehaviour, ICraft
    {
        [Inject] private ICraftController _craftController;
        [Inject] protected IProductStore _productStore;
        public IProductStore ProductStore
        {
            get { return _productStore; }
        }

        [Inject] private CraftAction _craftAction;

        protected string _productType;
        public string ProductType
        {
            get { return _productType; }
            set { _productType = value; }
        }

        [SerializeField] protected List<ProductData> _productList;
        public List<ProductData> ProductList
        {
            get { return _productList; }
        }

        public void CraftProduct()
        {
            if (!_craftAction.IsEnoughParts())
            {
                return;
            }

            var coroutine = StartCoroutine(_craftAction.CraftTimer());
            _craftController.Add($"{_productType}Craft", coroutine);
        }
    }
}
