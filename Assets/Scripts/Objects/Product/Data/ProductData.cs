using UnityEngine;

namespace Scripts.Objects.Product
{
    [CreateAssetMenu(fileName = "ProductData", menuName = "Scriptable/Product Data", order = 51)]
    public class ProductData : ScriptableObject
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
}