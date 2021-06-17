using Assets.Scripts.Stores.Product.Recipe;
using Assets.Scripts.Stores.Product.Types;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable IdentifierTypo

namespace Assets.Scripts.Stores.Craft
{
    public interface ICraftable
    {
        GameObject GameObject { get; set; }
        string Name { get; set; }
        ProductType ProductType { get; set; }
        List<int> Count { get; set; }

        Sprite Icon { get; set; }
        GameObject Model { get; set; }

        int Experience { get; set; }

        List<RecipeScriptable> Recipes { get; set; }
    }
}
