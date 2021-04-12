using Scripts.Objects.Component;
using System;
using System.Collections.Generic;

namespace Scripts.Objects.Product
{
    [Serializable]
    public class RecipeObject
    {
        public string RecipeName;

        public ProductQuality Quality;
        public List<ComponentObject> Components;

        public int CraftTime;
    }
}
