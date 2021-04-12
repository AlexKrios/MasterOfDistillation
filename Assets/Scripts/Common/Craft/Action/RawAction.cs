using Scripts.Objects.Component;
using Scripts.Stores.Raw;
using Zenject;

namespace Scripts.Common.Craft.Action
{
    public class RawAction
    {
        [Inject] private IRawStore _rawStore;

        public bool IsEnoughRaw(ComponentObject component)
        {
            var componentValue = component.Count;

            var storeProperty = _rawStore.GetType().GetProperty(component.ProductName);
            var storeValue = (int)storeProperty.GetValue(_rawStore, null);

            if (storeValue - componentValue < 0)
            {
                return false;
            }

            return true;
        }

        public void RemoveRaw(ComponentObject component)
        {
            var componentValue = component.Count;

            var storeProperty = _rawStore.GetType().GetProperty(component.ProductName);
            var storeValue = (int)storeProperty.GetValue(_rawStore, null);

            storeProperty.SetValue(_rawStore, storeValue - componentValue, null);
        }
    }    
}
