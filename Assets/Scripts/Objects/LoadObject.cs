using Scripts.Objects.Money;
using Scripts.Objects.Product;
using Scripts.Objects.Raw;
using Scripts.Objects.Stores;
using System;
using System.Collections.Generic;

namespace Scripts.Objects
{
    [Serializable]
    public class LoadObject
    {
        public MoneyObject MoneyInfo;
        public LevelObject LevelInfo;
        public RawObject Raw;
        public RifleStoreObject RifleStoreInfo;
        public List<ProductObject> ProductsInfo;
        public List<LevelExperienceObject> LevelExperienceInfo;
    }
}
