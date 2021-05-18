using System.Collections.Generic;
using Assets.Scripts.Ui.Craft.Tab;
using UnityEngine;

namespace Assets.Scripts.Ui.Common.ProductMenu
{
    public interface ITabsGroup
    {
        List<ITabButton> Tabs { get; set; }
        ITabButton ActiveTab { get; set; }

        Sprite BgInactive { get; }
        Sprite BgActive { get; }

        void SubscribeTabToList(TabButton button);
        void ClearTabList();
    }
}
