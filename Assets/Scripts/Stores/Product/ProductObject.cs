using Assets.Scripts.Stores.Craft;
using Assets.Scripts.Stores.Product.Recipe;
using Assets.Scripts.Stores.Product.Types;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Stores.Product
{
    [Serializable]
    public class ProductObject : ICraftable, IPart
    {
        public GameObject GameObject { get; set; }

        public string Name { get; set; }

        public ItemType ItemType { get; set; }
        public ProductType ProductType { get; set; }

        public Sprite Icon { get; set; }
        public GameObject Model { get; set; }

        public int Experience { get; set; }

        public List<int> Count { get; set; }

        public List<RecipeScriptable> Recipes { get; set; }
    }
}
