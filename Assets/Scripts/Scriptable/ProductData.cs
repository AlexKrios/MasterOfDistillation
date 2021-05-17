using Assets.Scripts.Objects.Item.Product.Types;
using JetBrains.Annotations;
using UnityEngine;
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
#pragma warning disable 649

namespace Assets.Scripts.Scriptable
{
    [CreateAssetMenu(fileName = "ProductData", menuName = "Scriptable/Product Data", order = 51)]
    [UsedImplicitly]
    public class ProductData : ScriptableObject
    {
        [SerializeField] private string _name;
        public string Name => _name;

        [SerializeField] private ProductType _type;
        public ProductType Type => _type;

        [SerializeField] private ProductSubType _subType;
        public ProductSubType SubType => _subType;

        [SerializeField] private Sprite _icon;
        public Sprite Icon => _icon;
    }
}