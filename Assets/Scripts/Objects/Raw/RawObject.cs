using System;

namespace Scripts.Objects.Raw
{
    [Serializable]
    public class RawObject
    {
        public ObjectData Data;

        public int Count;
        public int Level;

        public RawSettingsObject Settings;
    }
}
