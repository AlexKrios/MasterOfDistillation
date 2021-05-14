using Assets.Scripts.Objects.Product.Part;
using Assets.Scripts.Stores.Product;
using Zenject;

namespace Assets.Scripts.Common.Craft.Action
{
    public class ComponentAction : ICraftPartAction
    {
        [Inject] private readonly IProductStore _store;

        public bool IsEnough(PartObject part)
        {
            var partName = part.Data.Name;            
            var partSubType = part.Data.SubType;
            var partQuality = part.Quality;
            var partCount = part.Count;

            var store = _store.AllStore[partSubType.ToString()];
            var storeValue = store[partName].Count[(int)partQuality];

            if (storeValue - partCount < 0)
            {
                return false;
            }

            return true;
        }

        public void Remove(PartObject part)
        {
            var partName = part.Data.Name;
            var partSubType = part.Data.SubType;
            var partQuality = part.Quality;

            var store = _store.AllStore[partSubType.ToString()];
            store[partName].Count[(int)partQuality]--;
        }
    }    
}
