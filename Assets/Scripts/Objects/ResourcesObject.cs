using Scripts.Objects.Money;
using System;
using System.Collections.Generic;

namespace Scripts.Objects
{
    [Serializable]
    public class ResourcesObject
    {
        public List<LevelExpObject> levelExpInfo;
        public LevelObject levelInfo;
        public MoneyObject moneyInfo;        
    }
}
