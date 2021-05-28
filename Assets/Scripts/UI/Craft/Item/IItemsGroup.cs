using UnityEngine;

namespace Assets.Scripts.Ui.Craft.Item
{
    public interface IItemsGroup
    {
        RectTransform Container { get; }
        IItemButton ActiveItem { get; set; }

        void CreateMenuItems();
        void ResetMenuItems();
    }
}
