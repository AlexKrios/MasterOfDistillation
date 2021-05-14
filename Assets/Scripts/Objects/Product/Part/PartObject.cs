using System;
using Assets.Scripts.Objects.Product.Data;

namespace Assets.Scripts.Objects.Product.Part
{
    [Serializable]
    public class PartObject
    {
        public ProductData Data;
        public ProductQuality Quality;
        public int Count;
    }
}
