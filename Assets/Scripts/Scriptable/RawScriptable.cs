using Assets.Scripts.Objects.Item;
using Assets.Scripts.Objects.Item.Raw;
using JetBrains.Annotations;
using UnityEngine;
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
#pragma warning disable 649

namespace Assets.Scripts.Scriptable
{
    [CreateAssetMenu(fileName = "RawData", menuName = "Scriptable/Raw Data", order = 51)]
    [UsedImplicitly]
    public class RawScriptable : ScriptableObject
    {
        [SerializeField] private string _name;
        public string Name => _name;

        [SerializeField] private ItemType _itemType;
        public ItemType ItemType => _itemType;
        [SerializeField] private RawType _rawType;
        public RawType RawType => _rawType;

        [SerializeField] private Sprite _icon;
        public Sprite Icon => _icon;
    }
}