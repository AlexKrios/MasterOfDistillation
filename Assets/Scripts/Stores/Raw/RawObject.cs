using Assets.Scripts.Stores.Product.Recipe;
using System;

namespace Assets.Scripts.Stores.Raw
{
    [Serializable]
    public class RawObject : IRaw, IPart
    {
        public string Name { get; set; }

        public ItemType ItemType { get; set; }
        public RawType RawType { get; set; }

        public int Count { get; set; }

        public RawSettingsObject Settings { get; set; }
    }
}
