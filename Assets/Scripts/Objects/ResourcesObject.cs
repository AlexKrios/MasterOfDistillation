using System;
using System.Collections.Generic;

namespace Scripts.Objects
{
    [Serializable]
    public class ResourcesObject
    {
        public GoldObject goldInfo;
        public LevelObject levelInfo;
        public List<LevelExpObject> levelExpInfo;
    }
}
