using Scripts.Objects.Product;
using Scripts.Stores;
using Scripts.UI.Product;
using System.Collections;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Scripts.Common.Craft
{
    public class CraftComponent
    {
        [Inject] private ICraftController _craftController;
        [Inject] protected IProductUIController _productUIStore;

        [Inject] private RawAction _rawAction;
        [Inject] private ComponentAction _componentAction;

        private ProductObject _productObject;
        private IProductStore _productStore;

        private string _quality;
        private RecipeObject _recipe;

        public bool IsEnoughIngridients()
        {
            _productObject = _craftController.ActiveProduct;
            _productStore = _craftController.ActiveStore;

            _quality = _productObject.Quality;
            _recipe = _productObject.Recipes.First(x => x.Quality == _quality);

            if (!_rawAction.IsEnoughRaw(_recipe) || !_componentAction.IsEnoughComponents())
            {
                Debug.LogWarning("Нехватает ингридиентов");
                return false;
            }

            return true;
        }

        public IEnumerator CraftTimer()
        {
            _rawAction.RemoveRaw(_recipe);
            //_componentAction.RemoveComponents();

            var countdownValue = _recipe.CraftTime;
            while (countdownValue > 0)
            {
                yield return new WaitForSeconds(1.0f);
                countdownValue--;
            }

            CompleteCraft();
        }

        private void CompleteCraft()
        {
            foreach (var component in _productStore.Components)
            {
                if (component.Quality == _quality)
                {
                    component.Count++;
                    _productUIStore.OnSetComponentText.Invoke();

                    Debug.Log($"Производство завершено. Component {_quality}: {component.Count}");

                    break;
                }
            }

            _craftController.Remove($"{_productObject.SubType}Craft");
        }
    }
}
