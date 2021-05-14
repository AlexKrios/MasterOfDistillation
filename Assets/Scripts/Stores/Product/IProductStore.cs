using System.Collections.Generic;
using Assets.Scripts.Objects.Product.Data;
using Scripts.Objects.Product.Load;

namespace Assets.Scripts.Stores.Product
{
    public interface IProductStore
    {
        Dictionary<string, Dictionary<string, ProductFullData>> AllStore { get; }

        void LoadItemsCount(List<ProductLoadObject> storesInfo);
        void SetProductExperience(string name);
    }
}
