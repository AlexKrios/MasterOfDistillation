using Scripts.Stores;
using System.Collections;
using UnityEngine;

namespace Scripts.Scenes.Main.Craft
{
    public class CraftIngridient
    {
        private ProductQuality _quality;
        private IProductStore _store;

        public IEnumerator Execute(ProductQuality quality, IProductStore store)
        {
            _quality = quality;
            _store = store;

            if (!CheckIfEnoughIngridients())
            {
                Debug.LogWarning("Нехватает ингридиентов");
                yield break;
            }

            RemoveIngridients();

            var countdownValue = 3;
            while (countdownValue > 0)
            {
                //Debug.Log("Countdown: " + countdownValue);
                yield return new WaitForSeconds(1.0f);
                countdownValue--;
            }

            CompleteProduction();
        }

        private bool CheckIfEnoughIngridients()
        {
            var test = new { Raw = 13, IngredientCommon = 1 };
            var properties = test.GetType().GetProperties();

            foreach (var property in properties)
            {
                var storeProperty = _store.GetType().GetProperty(property.Name);
                var storeValue = (int)storeProperty.GetValue(_store, null);

                var objectValue = (int)property.GetValue(test, null);

                if (storeValue - objectValue < 0)
                {
                    return false;
                }                
            }

            return true;
        }

        private void RemoveIngridients()
        {
            var test = new { Raw = 3, IngredientCommon = 1 };
            var properties = test.GetType().GetProperties();

            foreach (var property in properties)
            {
                var storeProperty = _store.GetType().GetProperty(property.Name);
                var storeValue = (int)storeProperty.GetValue(_store, null);

                var objectValue = (int)property.GetValue(test, null);

                storeProperty.SetValue(_store, storeValue - objectValue, null);
            }
        }

        private void CompleteProduction()
        {
            var ingridient = _store.GetType().GetProperty($"Ingredient{_quality}");
            var count = (int)ingridient.GetValue(_store, null);
            ingridient.SetValue(_store, count + 1, null);

            Debug.Log($"Производство заверщено. Ingredient{_quality}: {count}");
        }
    }
}
