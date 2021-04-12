using Scripts.Objects.Product;
using Scripts.Stores;
using Scripts.UI;
using System.Collections;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Scripts.Common.Craft.Action
{
    public class CraftAction
    {
        [Inject] private IUiController _uiController;
        [Inject] private ICraftController _craftController;

        [Inject] private RawAction _rawAction;

        private IProductStore _productStore 
        {
           get { return _uiController.ActiveBuilding.GetComponent<ICraft>().ProductStore; }
        }
        private ProductData _productData { get => _craftController.ActiveProduct; }
        private ProductQuality _productQuality { get => _craftController.ProductQuality; }
        private RecipeObject _recipe;

        public bool IsEnoughParts()
        {        
            _recipe = _productData.Recipes.First(x => x.Quality == _productQuality);

            bool isEnough = true;

            foreach (var component in _recipe.Components) 
            {                
                switch (component.Type)
                {
                    case "Raw":
                        isEnough = _rawAction.IsEnoughRaw(component);
                        break;

                    default:
                        return true;
                }

                if (!isEnough)
                {
                    Debug.LogWarning("Нехватает ингридиентов");
                    return false;
                }
            }

            return isEnough;
        }

        public IEnumerator CraftTimer()
        {
            RemoveParts();

            var countdownValue = _recipe.CraftTime;
            while (countdownValue > 0)
            {
                yield return new WaitForSeconds(1.0f);
                countdownValue--;
            }

            CompleteCraft();
        }

        public void RemoveParts()
        {
            foreach (var component in _recipe.Components)
            {
                switch (component.Type)
                {
                    case "Raw":
                        _rawAction.RemoveRaw(component);
                        break;

                    default:
                        break;
                }
            }
        }

        private void CompleteCraft()
        {
            Debug.Log($"Craft {_productData.ProductName} complete");

            var product = _productStore.RifleStoreList.First(x => 
                x.Slug == _productData.Slug && x.Quality == _productQuality
            );

            product.Count++;
        }
    }    
}
