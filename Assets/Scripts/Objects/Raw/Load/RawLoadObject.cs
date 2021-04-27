using System;

namespace Scripts.Objects.Raw.Load
{
    [Serializable]
    public class RawLoadObject
    {
        public string Name;

        public int Count;
        public int Level;

        public RawSettingsObject Settings;
    }
}
