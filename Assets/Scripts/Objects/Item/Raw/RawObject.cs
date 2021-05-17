using Assets.Scripts.Objects.Item.Raw.Settings;
using Assets.Scripts.Objects.Item.Recipe;
using System;

namespace Assets.Scripts.Objects.Item.Raw
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
