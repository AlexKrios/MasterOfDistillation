using Scripts.Objects.Product;
using System;

namespace Scripts.Objects.Part
{
    [Serializable]
    public class PartObject
    {
        public ProductData Data;
        public ProductQuality Quality;
        public int Count;
    }
}
