using Scripts.Objects.Product;
using Scripts.Stores.Raw;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Scripts.Common.Craft
{
    public class RawAction
    {
        [Inject] private IRawStore _rawStore;

        public bool IsEnoughRaw(RecipeObject recipe)
        {
            var fields = recipe.Raw.GetType().GetFields();
            var isNotNull = fields.Any(x => (int)x.GetValue(recipe.Raw) != 0);

            if (!isNotNull)
            {
                return true;
            }

            foreach (var field in fields)
            {
                var storeProperty = _rawStore.GetType().GetProperty(field.Name);
                var storeValue = (int)storeProperty.GetValue(_rawStore, null); 

                var objectValue = (int)field.GetValue(recipe.Raw);

                if (storeValue - objectValue < 0)
                {
                    return false;
                }
            }

            return true;
        }

        public void RemoveRaw(RecipeObject recipe)
        {
            var fields = recipe.Raw.GetType().GetFields();

            foreach (var field in fields)
            {
                var storeProperty = _rawStore.GetType().GetProperty(field.Name);
                var storeValue = (int)storeProperty.GetValue(_rawStore, null);

                var objectValue = (int)field.GetValue(recipe.Raw);

                storeProperty.SetValue(_rawStore, storeValue - objectValue, null);
            }
        }
    }    
}
