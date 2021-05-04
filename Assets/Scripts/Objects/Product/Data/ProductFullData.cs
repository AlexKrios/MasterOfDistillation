using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Objects.Product
{
    [CreateAssetMenu(fileName = "New ProductFullData", menuName = "Product Full Data", order = 51)]
    public class ProductFullData : ScriptableObject
    {
        public GameObject GameObject { get; set; }
        public List<int> Count { get; set; } = new List<int>() { 0, 0, 0, 0 };

        [SerializeField] private ProductData _data;
        public ProductData Data { get => _data; }

        [SerializeField] private List<RecipeObject> _recipes;
        public List<RecipeObject> Recipes { get => _recipes; }

        public void Reset()
        {
            Count = new List<int>() { 0, 0, 0, 0 };
        }
    }
}