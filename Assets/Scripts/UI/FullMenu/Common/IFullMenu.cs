using Assets.Scripts.Ui.FullMenu.Common.Item;
using Assets.Scripts.Ui.FullMenu.Common.Model;
using Assets.Scripts.Ui.FullMenu.Common.Part;
using Assets.Scripts.Ui.FullMenu.Common.Product;
using Assets.Scripts.Ui.FullMenu.Common.Quality;
using Assets.Scripts.Ui.FullMenu.Common.Tab;
using UnityEngine;

namespace Assets.Scripts.Ui.FullMenu.Common
{
    public interface IFullMenu
    {
        GameObject GameObject { get; }

        ITabButton ActiveTab { get; set; }
        IItemButton ActiveItem { get; set; }
        ProductQuality ActiveQuality { get; set; }

        ITabsGroup Tabs { get; set; }
        IItemsGroup Items { get; set; }

        IProductCell Product { get; set; }
        IPartGroup Parts { get; set; }
        IQualityButton Quality { get; set; }

        IModelGroup Model { get; set; }
    }
}
