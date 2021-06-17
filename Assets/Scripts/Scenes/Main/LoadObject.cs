using Assets.Scripts.Stores.Level;
using Assets.Scripts.Stores.Money;
using Assets.Scripts.Stores.Product.Load;
using Assets.Scripts.Stores.Raw;
using System;
using System.Collections.Generic;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Scenes.Main
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
