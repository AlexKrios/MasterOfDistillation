using Assets.Scripts.Objects.Item;
using JetBrains.Annotations;
using UnityEngine;
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
#pragma warning disable 649

namespace Assets.Scripts.Scriptable
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable/Item Data", order = 51)]
    [UsedImplicitly]
    public class ItemScriptable : ScriptableObject
    {
        [SerializeField] private string _name;
        public string Name => _name;

        [SerializeField] private ItemType _itemType;
        public ItemType ItemType => _itemType;

        [SerializeField] private Sprite _icon;
        public Sprite Icon => _icon;

        [SerializeField] private GameObject _model;
        public GameObject Model => _model;
    }
}