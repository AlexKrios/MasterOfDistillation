using Assets.Scripts.Objects.Item.Raw.Settings;
using System;

namespace Assets.Scripts.Objects.Item.Raw.Load
{
    [Serializable]
    public class RawLoadObject
    {
        public string Name;

        public int Count;

        public RawSettingsObject Settings;
    }
}
