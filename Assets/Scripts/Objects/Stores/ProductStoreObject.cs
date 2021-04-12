using System;

namespace Scripts.Objects.Product
{
    [Serializable]
    public class ProductStoreObject
    {
        public string ProductName;
        public string Slug;

        public string Type;
        public string SubType;

        public ProductQuality Quality;

        public int Count;
    }
}
