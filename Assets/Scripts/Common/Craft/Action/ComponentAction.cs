using Assets.Scripts.Objects.Item.Recipe;
using Assets.Scripts.Stores.Product;
using Zenject;

namespace Assets.Scripts.Common.Craft.Action
{
    public class ComponentAction : ICraftPartAction
    {
        [Inject] private readonly IProductStore _productStore;

        public bool IsEnough(PartObject part)
        {
            var partName = part.Data.Name;
            var partQuality = part.Quality;
            var partCount = part.Count;

            var storeValue = _productStore.Store[partName].Count[(int)partQuality];

            return storeValue - partCount >= 0;
        }

        public void Remove(PartObject part)
        {
            var partName = part.Data.Name;
            var partQuality = part.Quality;

            _productStore.Store[partName].Count[(int)partQuality]--;
        }
    }    
}
