using Scripts.Stores;
using System.Collections.Generic;

namespace Scripts.Common.Craft
{
    public interface ICraft
    {        
        string ProductType { get; set; }
        IProductStore ProductStore { get; }
        List<ProductData> ProductList { get; }

        void CraftProduct();
    }
}
