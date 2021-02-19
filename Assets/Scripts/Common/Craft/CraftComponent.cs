using Scripts.Objects.Product;
using Scripts.Stores;
using Scripts.Stores.Product;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Scripts.Common.Craft
{
    public class CraftComponent
    {
        [Inject] private ICraftController _craftController;
        [Inject] private RecipesStore _recipesStore;

        [Inject] private RawAction _rawAction;
        [Inject] private ComponentAction _componentAction;

        private RecipeObject _recipe;

        private ProductQuality _quality;
        private IProductStore _store;

        public IEnumerator Execute(ProductQuality quality, IProductStore store)
        {
            _quality = quality;
            _store = store;

            _recipe = _recipesStore.Recipes[0];

            if (!_rawAction.IsEnoughRaw() || !_componentAction.IsEnoughComponents())
            {
                Debug.LogWarning("Нехватает ингридиентов");
                yield break;
            }

            _rawAction.RemoveRaw();
            //_componentAction.RemoveComponents();

            var countdownValue = _recipe.CraftTime;
            while (countdownValue > 0)
            {
                //Debug.Log("Countdown: " + countdownValue);
                yield return new WaitForSeconds(1.0f);
                countdownValue--;
            }

            CompleteCraft();
        }

        private void CompleteCraft()
        {
            var component = _store.GetType().GetProperty($"Component{_quality}");
            var count = (int)component.GetValue(_store, null);
            component.SetValue(_store, count + 1, null);
            var newCount = (int)component.GetValue(_store, null);

            Debug.Log($"Производство завершено. Component{_quality}: {newCount}");
        }
    }
}
