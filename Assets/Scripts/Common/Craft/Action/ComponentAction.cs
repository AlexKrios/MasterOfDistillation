using Scripts.Objects.Part;
using Scripts.Stores;
using Zenject;

namespace Scripts.Common.Craft.Action
{
    public class ComponentAction
    {
        [Inject] private IStore _store;

        public bool IsEnoughComponents(PartObject part)
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

        public void RemoveComponents(PartObject part)
        {
            var partName = part.Data.Name;
            var partSubType = part.Data.SubType;
            var partQuality = part.Quality;

            var store = _store.AllStore[partSubType.ToString()];
            store[partName].Count[(int)partQuality]--;
        }
    }    
}
