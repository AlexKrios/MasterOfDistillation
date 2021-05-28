using UnityEngine;

namespace Assets.Scripts.Ui.Craft.Tab
{
    public interface ITabsGroup
    {
        ITabButton ActiveTab { get; set; }

        Sprite BgInactive { get; }
        Sprite BgActive { get; }

        void SubscribeTabToList(TabButton button);
    }
}
