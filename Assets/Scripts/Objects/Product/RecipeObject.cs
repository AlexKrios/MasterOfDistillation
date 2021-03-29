using Scripts.Objects.Component;
using Scripts.Objects.Raw;
using System;
using System.Collections.Generic;

namespace Scripts.Objects.Product
{
    [Serializable]
    public class RecipeObject
    {
        public string Quality;

        public RawStoreObject Raw;
        public List<ComponentObject> Components;

        public int CraftTime;
    }
}
