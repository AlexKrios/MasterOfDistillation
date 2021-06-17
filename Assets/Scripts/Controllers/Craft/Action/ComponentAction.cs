using Assets.Scripts.Stores.Product;
using Assets.Scripts.Stores.Product.Recipe;
using JetBrains.Annotations;
using Zenject;

namespace Assets.Scripts.Controllers.Craft.Action
{
    [UsedImplicitly]
    public class ComponentAction : ICraftPartAction
    {
        [Inject] private readonly IProductStore _productStore;

        public bool IsEnough(PartObject part)
        {
            var partName = part.Data.Name;
            var partQuality = part.Quality;
            var partCount = part.Count;

            var storeValue = _productStore.ItemsDictionary[partName].Count[(int)partQuality];

            return storeValue - partCount >= 0;
        }

        public void Remove(PartObject part)
        {
            var partName = part.Data.Name;
            var partQuality = part.Quality;

            _productStore.ItemsDictionary[partName].Count[(int)partQuality]--;
        }
    }    
}
