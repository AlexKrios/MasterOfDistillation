using System;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Stores.Product.Recipe
{
    [Serializable]
    public class PartObject
    {
        public ItemScriptable Data;
        public ProductQuality Quality;
        public int Count;
    }
}
