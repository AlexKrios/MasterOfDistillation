using Scripts.Objects.Part;
using System;
using System.Collections.Generic;

namespace Scripts.Objects.Product
{
    [Serializable]
    public class RecipeObject
    {
        public string Name;

        public ProductQuality Quality;
        public List<PartObject> Parts;

        public int CraftTime;
    }
}
