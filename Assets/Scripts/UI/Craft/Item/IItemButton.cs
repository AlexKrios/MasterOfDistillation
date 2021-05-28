using Assets.Scripts.Objects.Item;
using UnityEngine;

namespace Assets.Scripts.Ui.Craft.Item
{
    public interface IItemButton
    {
        ICraftable Product { get; }

        Sprite BgInactive { get; }
        Sprite BgActive { get; }

        void SetItemInactive();
        void SetItemActive();
    }
}
