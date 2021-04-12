using Scripts.Objects.Product;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ProductData", menuName = "Product Data", order = 51)]
public class ProductData : ScriptableObject
{
    [SerializeField] private string _productName;
    public string ProductName 
    {
        get { return _productName; }
    }

    [SerializeField] private string _slug;
    public string Slug
    {
        get { return _slug; }
    }

    [SerializeField] private string _type;
    public string Type
    {
        get { return _type; }
    }

    [SerializeField] private string _subType;
    public string SubType
    {
        get { return _subType; }
    }

    [SerializeField] private List<RecipeObject> _recipes;
    public List<RecipeObject> Recipes
    {
        get { return _recipes; }
    }
}
