using Scripts.Objects.Product;
using System.Collections.Generic;

namespace Scripts.Stores.Product
{
    public interface IRecipesStore
    {
        List<ProductObject> Recipes { get; set; }
        ProductObject FindBySlug(string slug);
        List<ProductObject> FindBySubType(string subType);
    }
}
