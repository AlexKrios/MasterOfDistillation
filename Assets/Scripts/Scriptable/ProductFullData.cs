using Assets.Scripts.Objects.Item.Recipe;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649

namespace Assets.Scripts.Scriptable
{
    [CreateAssetMenu(fileName = "ProductFullData", menuName = "Scriptable/Product Full Data", order = 51)]
    public class ProductFullData : ScriptableObject
    {
        public GameObject GameObject { get; set; }
        public List<int> Count { get; set; }

        [SerializeField] private ProductData _data;
        public ProductData Data => _data;

        [SerializeField] private List<RecipeObject> _recipes;
        public List<RecipeObject> Recipes => _recipes;

        public ProductFullData()
        {
            Count = new List<int>() { 0, 0, 0, 0 };
        }

        public void Reset()
        {
            Count = new List<int>() { 0, 0, 0, 0 };
        }
    }
}