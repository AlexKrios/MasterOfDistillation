using Scripts.Objects.Product;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object Data", menuName = "Object Data", order = 51)]
public class ObjectData : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name 
    {
        get { return _name; }
        set { _name = value; }
    }

    [SerializeField] private ProductType _type;
    public ProductType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    [SerializeField] private ProductSubType _subType;
    public ProductSubType SubType
    {
        get { return _subType; }
        set { _subType = value; }
    }

    [SerializeField] private Sprite _icon;
    public Sprite Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }
}
