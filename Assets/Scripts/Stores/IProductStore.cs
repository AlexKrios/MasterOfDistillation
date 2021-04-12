using Scripts.Objects.Product;
using System.Collections.Generic;

namespace Scripts.Stores
{
    public interface IProductStore 
    {
        List<ProductStoreObject> RifleStoreList { get; set; }
    }
}
