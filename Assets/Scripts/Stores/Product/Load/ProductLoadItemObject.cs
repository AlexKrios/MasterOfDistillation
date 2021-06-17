using System;
using System.Collections.Generic;

namespace Assets.Scripts.Stores.Product.Load
{
    [Serializable]
    public class ProductLoadItemObject
    {
        public string Name;
        public string Slug;
        public List<int> Count;
        public List<int> Experience;
    }
}
