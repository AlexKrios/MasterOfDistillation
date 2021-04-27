using Scripts.Objects.Product.Load;
using System.Collections.Generic;

namespace Scripts.Stores
{
    public interface IStore
    {
        string ItemSubType { get; }
        Dictionary<string, Dictionary<string, ProductData>> AllStore { get; }
        Dictionary<string, ProductData> Data { get; }

        void LoadItemsCount(List<ProductLoadObject> storesInfo);
    }
}
