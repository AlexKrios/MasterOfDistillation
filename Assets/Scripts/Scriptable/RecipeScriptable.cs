using Assets.Scripts.Objects.Item.Recipe;
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
#pragma warning disable 649

namespace Assets.Scripts.Scriptable
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "Scriptable/New Item Recipe", order = 51)]
    [UsedImplicitly]
    public class RecipeScriptable : ScriptableObject
    {
        [SerializeField] private ProductQuality _quality;
        public ProductQuality Quality => _quality;  

        [SerializeField] private List<PartObject> _parts;
        public List<PartObject> Parts => _parts;

        [SerializeField] private int _level;
        public int Level => _level;
        [SerializeField] private int _experience;
        public int Experience => _experience;

        [SerializeField] private int _craftTime;
        public int CraftTime => _craftTime;
    }
}
