using Assets.Scripts.UI.Craft.Item;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Ui.Common.ProductMenu
{
    public interface IItemsGroup
    {
        RectTransform Container { get; }
        Dictionary<string, ItemButton> Items { get; set; }
        IItemButton ActiveItem { get; set; }

        void CreateMenuItems();
        void ResetMenuItems();
    }
}
