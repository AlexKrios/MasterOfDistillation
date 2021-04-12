using System;

namespace Scripts.Objects.Component
{
    [Serializable]
    public class ComponentObject
    {
        public string ProductName;
        public string Type;
        public ProductQuality Quality;
        public int Count;
    }
}
