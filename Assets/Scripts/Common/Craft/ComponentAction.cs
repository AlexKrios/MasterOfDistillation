using Scripts.Objects.Product;
using Scripts.Stores.Product;
using Scripts.Stores.Raw;
using System.Linq;
using Zenject;

namespace Scripts.Common.Craft
{
    public class ComponentAction
    {
        [Inject] private IRawStore _rawStore;
        [Inject] private IRecipesStore _recipesStore;

        private RecipeObject _recipe;

        public bool IsEnoughComponents()
        {
            //_recipe = _recipesStore.Recipes[0];

            //var fields = _recipe.Component.GetType().GetFields();
            //var isNotNull = fields.Any(x => (int)x.GetValue(_recipe.Component) != 0);

            //if (!isNotNull)
            //{
            //    return true;
            //}

            //foreach (var field in fields)
            //{
            //    var storeProperty = _rawStore.GetType().GetProperty(field.Name);
            //    var storeValue = (int)storeProperty.GetValue(_rawStore, null);

            //    var objectValue = (int)field.GetValue(_recipe.Component);

            //    if (storeValue - objectValue < 0)
            //    {
            //        return false;
            //    }
            //}

            return true;
        }

        public void RemoveComponents()
        {
            //var fields = _recipe.Component.GetType().GetFields();

            //foreach (var field in fields)
            //{
            //    var storeProperty = _rawStore.GetType().GetProperty(field.Name);
            //    var storeValue = (int)storeProperty.GetValue(_rawStore, null);

            //    var objectValue = (int)field.GetValue(_recipe.Component);

            //    storeProperty.SetValue(_rawStore, storeValue - objectValue, null);
            //}
        }
    }    
}
