using System;
using System.Collections.Generic;

namespace Assets.Scripts.Objects.Product
{
    [Serializable]
    public class ProductObject
    {
        public string Name;
        public string Slug;

        public string Type;
        public string SubType;

        public string Quality;

        public List<RecipeObject> Recipes;
    }
}
