using Scripts.Objects.Product;
using Scripts.Stores.Product;
using Scripts.Stores.Raw;
using System.Linq;
using Zenject;

namespace Scripts.Common.Craft
{
    public class RawAction
    {
        [Inject] private IRawStore _rawStore;
        [Inject] private RecipesStore _recipesStore;

        private RecipeObject _recipe;

        public bool IsEnoughRaw()
        {
            _recipe = _recipesStore.Recipes[0];

            var fields = _recipe.Raw.GetType().GetFields();
            var isNotNull = fields.Any(x => (int)x.GetValue(_recipe.Raw) != 0);

            if (!isNotNull)
            {
                return true;
            }

            foreach (var field in fields)
            {
                var storeProperty = _rawStore.GetType().GetProperty(field.Name);
                var storeValue = (int)storeProperty.GetValue(_rawStore, null);

                var objectValue = (int)field.GetValue(_recipe.Raw);

                if (storeValue - objectValue < 0)
                {
                    return false;
                }
            }

            return true;
        }

        public void RemoveRaw()
        {
            var fields = _recipe.Raw.GetType().GetFields();

            foreach (var field in fields)
            {
                var storeProperty = _rawStore.GetType().GetProperty(field.Name);
                var storeValue = (int)storeProperty.GetValue(_rawStore, null);

                var objectValue = (int)field.GetValue(_recipe.Raw);

                storeProperty.SetValue(_rawStore, storeValue - objectValue, null);
            }
        }
    }    
}
