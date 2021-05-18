using Assets.Scripts.Objects.Item;
using UnityEngine;

namespace Assets.Scripts.Ui.Common.ProductMenu
{
    public interface IItemButton
    {
        ICraftable Product { get; set; }

        Sprite BgInactive { get; }
        Sprite BgActive { get; }

        void SetItemInactive();
        void SetItemActive();
    }
}
