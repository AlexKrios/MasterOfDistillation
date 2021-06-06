using Assets.Scripts.Objects.Item.Product.Types;
using Assets.Scripts.Objects.Item.Recipe;
using Assets.Scripts.Scriptable;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Objects.Item.Component
{
    [Serializable]
    public class ComponentObject : IComponent, ICraftable, IPart
    {
        public GameObject GameObject { get; set; }

        public string Name { get; set; }

        public ItemType ItemType { get; set; }
        public ProductType ProductType { get; set; }

        public Sprite Icon { get; set; }
        public GameObject Model { get; set; }

        public int Level { get; set; }
        public int Experience { get; set; }
        public List<int> LevelCaps { get; set; }

        public List<int> Count { get; set; }

        public List<RecipeScriptable> Recipes { get; set; }
    }
}
