using Assets.Scripts.Scriptable;
using System;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Objects.Item.Recipe
{
    [Serializable]
    public class PartObject
    {
        public ItemScriptable Data;
        public ProductQuality Quality;
        public int Count;
    }
}
