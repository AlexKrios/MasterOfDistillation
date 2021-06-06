using Assets.Scripts.Objects.Item.Recipe;
using Assets.Scripts.Stores.Raw;
using JetBrains.Annotations;
using Zenject;

namespace Assets.Scripts.Ui.FullMenu.Craft.Controller.Action
{
    [UsedImplicitly]
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
