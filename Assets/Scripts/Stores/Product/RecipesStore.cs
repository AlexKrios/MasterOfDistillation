using Scripts.Objects.Product;
using System.Collections.Generic;
using System.Linq;

namespace Scripts.Stores.Product
{
    public class RecipesStore : IRecipesStore
    {
        private List<ProductObject> _recipes;
        public List<ProductObject> Recipes 
        {
            get { return _recipes; }
            set { _recipes = value; }
        }

        public ProductObject FindBySlug(string slug)
        {
            return Recipes.FirstOrDefault(x => x.Slug == slug);
        }

        public List<ProductObject> FindBySubType(string subType)
        {
            return Recipes.FindAll(x => x.SubType == subType);
        }
    }
}
