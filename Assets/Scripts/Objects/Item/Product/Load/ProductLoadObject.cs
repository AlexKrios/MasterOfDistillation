using System;
using System.Collections.Generic;

namespace Assets.Scripts.Objects.Item.Product.Load
{
    [Serializable]
    public class ProductLoadObject
    {
        public string Name;
        public List<ProductLoadItemObject> Items;
    }
}
