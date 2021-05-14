using System;
using System.Collections.Generic;
using Assets.Scripts.Objects.Level;
using Assets.Scripts.Objects.Money;
using Assets.Scripts.Objects.Raw.Load;
using Scripts.Objects.Product.Load;

namespace Assets.Scripts.Objects
{
    [Serializable]
    public class LoadObject
    {
        public MoneyObject MoneyInfo;
        public LevelObject LevelInfo;
        public List<RawLoadObject> RawInfo;
        public List<ProductLoadObject> StoresInfo;
    }
}
