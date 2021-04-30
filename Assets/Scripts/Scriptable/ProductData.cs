using Scripts.Objects.Product;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ProductData", menuName = "Product Data", order = 51)]
public class ProductData : ScriptableObject
{
    private GameObject _gameObject;
    public GameObject GameObject
    {
        get { return _gameObject; }
        set { _gameObject = value; }
    }

    private List<int> _count = new List<int>() { 0, 0, 0, 0 };
    public List<int> Count
    {
        get { return _count; }
        set { _count = value; }
    }

    [SerializeField] private ObjectData _data;
    public ObjectData Data 
    {
        get { return _data; }
    }    

    [SerializeField] private List<RecipeObject> _recipes;
    public List<RecipeObject> Recipes
    {
        get { return _recipes; }
    }

    public void Reset()
    {
        Count = new List<int>() { 0, 0, 0, 0 };
    }
}
