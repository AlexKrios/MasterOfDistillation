using Scripts.Objects.Money;
using Scripts.Objects.Product.Load;
using Scripts.Objects.Raw.Load;
using System;
using System.Collections.Generic;

namespace Scripts.Objects
{
    [Serializable]
    public class LoadObject
    {
        public MoneyObject MoneyInfo;
        public LevelObject LevelInfo;
        public List<RawLoadObject> RawInfo;
        public List<ProductLoadObject> StoresInfo;
        public List<LevelExperienceObject> ExperienceMaxInfo;
    }
}
