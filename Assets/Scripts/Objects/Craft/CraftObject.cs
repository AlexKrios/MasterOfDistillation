using Scripts.Objects.Product;
using System;
using UnityEngine;

namespace Scripts.Objects.Craft
{
    [Serializable]
    public class CraftObject
    {
        public ProductFullData Item;
        public ProductQuality Quality;
        public Coroutine Coroutine;
    }
}
