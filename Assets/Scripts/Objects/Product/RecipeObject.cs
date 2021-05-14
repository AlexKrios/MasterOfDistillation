using System;
using System.Collections.Generic;
using Assets.Scripts.Objects.Product.Part;

namespace Assets.Scripts.Objects.Product
{
    [Serializable]
    public class RecipeObject
    {
        public string Name;

        public ProductQuality Quality;
        public List<PartObject> Parts;

        public int Level;
        public int Experience;

        public int CraftTime;
    }
}
