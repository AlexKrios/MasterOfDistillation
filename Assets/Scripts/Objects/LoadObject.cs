using Assets.Scripts.Objects.Item.Product.Load;
using Assets.Scripts.Objects.Item.Raw.Load;
using Assets.Scripts.Objects.Level;
using Assets.Scripts.Objects.Money;
using System;
using System.Collections.Generic;

// ReSharper disable UnassignedField.Global

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
