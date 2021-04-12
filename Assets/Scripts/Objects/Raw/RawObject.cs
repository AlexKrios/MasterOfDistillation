using System;

namespace Scripts.Objects.Raw
{
    [Serializable]
    public class RawObject
    {
        public string Name;

        public int Count;
        public int Level;

        public RawSettingsObject Settings;
    }
}
