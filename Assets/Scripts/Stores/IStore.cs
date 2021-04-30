using Scripts.Objects.Product.Load;
using System.Collections.Generic;

namespace Scripts.Stores
{
    public interface IStore
    {
        Dictionary<string, Dictionary<string, ProductData>> AllStore { get; }

        void LoadItemsCount(List<ProductLoadObject> storesInfo);
    }
}
