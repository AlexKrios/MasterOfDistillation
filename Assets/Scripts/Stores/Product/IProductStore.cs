using Scripts.Objects.Product;
using Scripts.Objects.Product.Load;
using System.Collections.Generic;

namespace Scripts.Stores.Product
{
    public interface IProductStore
    {
        Dictionary<string, Dictionary<string, ProductFullData>> AllStore { get; }

        void LoadItemsCount(List<ProductLoadObject> storesInfo);
        void SetProductExpirience(string name);
    }
}
