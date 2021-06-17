using System;
// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Stores.Level
{
    [Serializable]
    public class LevelObject
    {
        public int Level;
        public int Experience;

        public LevelSettings Settings;
    }
}
