using Assets.Scripts.Stores.Craft;
using Assets.Scripts.Stores.Product.Load;
using System.Collections.Generic;

namespace Assets.Scripts.Stores.Product
{
    public interface IProductStore
    {
        Dictionary<string, ICraftable> ItemsDictionary { get; }

        void LoadItemsCount(List<ProductLoadObject> storesInfo);
    }
}
