using System;
using UnityEngine;

namespace Scripts.Objects.Craft
{
    [Serializable]
    public class CraftObject
    {
        public ProductData Item;
        public ProductQuality Quality;
        public Coroutine Coroutine;
    }
}
