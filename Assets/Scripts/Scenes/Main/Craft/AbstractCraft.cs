using Scripts.Stores;
using UnityEngine;
using Zenject;

namespace Scripts.Scenes.Main.Craft
{
    public abstract class AbstractCraft : MonoBehaviour
    {
        protected IProductStore _productStore;
        private ICraftController _productionController;

        private CraftIngridient _ingridientProduction;

        protected string _productType;
        protected string ProductType
        {
            get { return _productType; }
            set { _productType = value; }
        }

        [Inject]
        public void Construct(ICraftController productionController, CraftIngridient ingridientProduction)
        {
            _ingridientProduction = ingridientProduction;
            _productionController = productionController;
        }

        public void IngridientCraft(ProductQuality quality = ProductQuality.Common)
        {
            var coroutine = StartCoroutine(_ingridientProduction.Execute(quality, _productStore));
            _productionController.Add($"{_productType}Craft", coroutine);
        }

        public void ProductCraft(ProductQuality quality = ProductQuality.Common)
        {
            var coroutine = StartCoroutine(_ingridientProduction.Execute(quality, _productStore));
            _productionController.Add($"{_productType}Craft", coroutine);
        }
    }
}
