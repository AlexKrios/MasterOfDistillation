using System;

namespace Assets.Scripts.Objects.Level
{
    [Serializable]
    public class LevelObject
    {
        public int Level;
        public int Experience;

        public LevelSettings Settings;
    }
}
