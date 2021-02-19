using Scripts.Objects.Money;
using Scripts.Objects.Product;
using Scripts.Objects.Raw;
using System;
using System.Collections.Generic;

namespace Scripts.Objects
{
    [Serializable]
    public class ResourcesObject
    {
        public MoneyObject MoneyInfo;
        public LevelObject LevelInfo;        
        public RawObject RawInfo;
        public List<RecipeObject> RecipesInfo;
        public List<LevelExperienceObject> LevelExperienceInfo;
    }
}
