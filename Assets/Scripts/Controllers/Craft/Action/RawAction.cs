using Assets.Scripts.Stores.Product.Recipe;
using Assets.Scripts.Stores.Raw;
using JetBrains.Annotations;
using Zenject;

namespace Assets.Scripts.Controllers.Craft.Action
{
    [UsedImplicitly]
    public class RawAction : ICraftPartAction
    {
        [Inject] private IRawStore _rawStore;

        public bool IsEnough(PartObject part)
        {
            var partCount = part.Count;
            var storeValue = _rawStore.RawData[part.Data.Name].Count;

            return storeValue - partCount >= 0;
        }

        public void Remove(PartObject part)
        {
            var partName = part.Data.Name;
            var partCount = part.Count;

            _rawStore.SetRawListData(partName, -partCount);
        }
    }    
}
