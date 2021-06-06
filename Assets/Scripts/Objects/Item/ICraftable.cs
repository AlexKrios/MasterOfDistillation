﻿using Assets.Scripts.Objects.Item.Product.Types;
using Assets.Scripts.Scriptable;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable IdentifierTypo

namespace Assets.Scripts.Objects.Item
{
    public interface ICraftable
    {
        GameObject GameObject { get; set; }
        string Name { get; set; }
        ProductType ProductType { get; set; }
        List<int> Count { get; set; }

        Sprite Icon { get; set; }
        GameObject Model { get; set; }

        int Level { get; set; }
        int Experience { get; set; }
        List<int> LevelCaps { get; set; }

        List<RecipeScriptable> Recipes { get; set; }
    }
}
