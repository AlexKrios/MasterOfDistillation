using System;
using System.Collections.Generic;
// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Objects.Item.Recipe
{
    [Serializable]
    public class RecipeObject
    {
        public ProductQuality Quality;

        public List<PartObject> Parts;

        public int Level;
        public int Experience;

        public int CraftTime;
    }
}
