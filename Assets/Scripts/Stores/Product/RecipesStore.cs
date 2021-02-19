using Scripts.Objects.Product;
using System.Collections.Generic;
using System.Linq;

namespace Scripts.Stores.Product
{
    public class RecipesStore
    {
        public List<RecipeObject> Recipes;

        public RecipeObject FindBySlug(string slug)
        {
            return Recipes.FirstOrDefault(x => x.Slug == slug);
        }
    }
}
