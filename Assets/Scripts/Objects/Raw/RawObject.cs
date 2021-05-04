using Scripts.Objects.Product;
using System;

namespace Scripts.Objects.Raw
{
    [Serializable]
    public class RawObject
    {
        public ProductData Data;

        public int Count;
        public int Level;

        public RawSettingsObject Settings;
    }
}
