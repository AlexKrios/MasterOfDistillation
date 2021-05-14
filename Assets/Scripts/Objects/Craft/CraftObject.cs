using System;
using Assets.Scripts.Objects.Product.Data;
using UnityEngine;

namespace Assets.Scripts.Objects.Craft
{
    [Serializable]
    public class CraftObject
    {
        public ProductFullData Item;
        public ProductQuality Quality;
        public Coroutine Timer;
    }
}
