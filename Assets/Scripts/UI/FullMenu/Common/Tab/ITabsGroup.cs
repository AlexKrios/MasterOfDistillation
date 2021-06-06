using UnityEngine;

namespace Assets.Scripts.Ui.FullMenu.Common.Tab
{
    public interface ITabsGroup
    {
        ITabButton ActiveTab { get; set; }

        Color BgInactive { get; }
        Color BgActive { get; }

        //void SetActiveTab();
        void SubscribeTabToList(ITabButton button);
    }
}
