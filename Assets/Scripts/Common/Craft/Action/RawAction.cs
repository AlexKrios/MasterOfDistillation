using Assets.Scripts.Objects.Product.Part;
using Assets.Scripts.Stores.Raw;
using Zenject;

namespace Assets.Scripts.Common.Craft.Action
{
    public class RawAction : ICraftPartAction
    {
        [Inject] private IRawStore _rawStore;

        public bool IsEnough(PartObject part)
        {
            var partCount = part.Count;
            var storeValue = _rawStore.RawData[part.Data.Name].Count;

            if (storeValue - partCount < 0)
            {
                return false;
            }

            return true;
        }

        public void Remove(PartObject part)
        {
            var partName = part.Data.Name;
            var partCount = part.Count;

            _rawStore.SetRawListData(partName, -partCount);
        }
    }    
}
