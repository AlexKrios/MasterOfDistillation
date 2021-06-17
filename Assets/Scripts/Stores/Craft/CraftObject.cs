using System;
using UnityEngine;

namespace Assets.Scripts.Stores.Craft
{
    [Serializable]
    public class CraftObject
    {
        public ICraftable Item;
        public ProductQuality Quality;
        public Coroutine Timer;
    }
}
