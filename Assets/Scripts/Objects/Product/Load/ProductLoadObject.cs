using System;
using System.Collections.Generic;

namespace Scripts.Objects.Product.Load
{
    [Serializable]
    public class ProductLoadObject
    {
        public string Name;
        public List<ProductLoadItemObject> Items;
    }
}
