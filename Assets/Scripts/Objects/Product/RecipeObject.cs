using Scripts.Objects.Raw;
using System;

namespace Scripts.Objects.Product
{
    [Serializable]
    public class RecipeObject
    {
        public string Name;
        public string Slug;

        public string Type;
        public string SubType;

        public string Quality;

        public RawObject Raw;
        public ComponentObject Component;

        public int CraftTime;
    }
}
