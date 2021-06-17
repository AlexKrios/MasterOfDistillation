using Assets.Scripts.Stores.Craft;
using System.Linq;
using UnityEngine.Events;

namespace Assets.Scripts.Controllers.Product
{
    public class ProductCountController
    {
        public SetCountEvent OnSetCount;

        public ProductCountController()
        {
            if (OnSetCount == null)
                OnSetCount = new SetCountEvent();

            OnSetCount.AddListener(SetProductCount);
        }

        public static bool CheckIfHaveCount(ICraftable item)
        {
            return item.Count.Any(count => count != 0);
        }

        private void SetProductCount(ICraftable item, ProductQuality quality)
        {
            item.Count[(int)quality]++;
        }
    }

    public class SetCountEvent : UnityEvent<ICraftable, ProductQuality> { }
}
