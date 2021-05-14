using System;
using Assets.Scripts.Objects.Product.Data;

namespace Assets.Scripts.Objects.Raw
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
