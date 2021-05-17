using System;
using UnityEngine;

namespace Assets.Scripts.Objects.Item.Craft
{
    [Serializable]
    public class CraftObject
    {
        public ICraftable Item;
        public ProductQuality Quality;
        public Coroutine Timer;
    }
}
