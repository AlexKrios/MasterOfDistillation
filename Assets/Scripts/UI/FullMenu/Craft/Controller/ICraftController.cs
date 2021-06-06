using Assets.Scripts.Objects.Item.Craft;
using System.Collections.Generic;

namespace Assets.Scripts.Ui.FullMenu.Craft.Controller
{
    public interface ICraftController
    {
        int CraftCellCount { get; set; }
        Dictionary<int, CraftObject> CraftList { get; }

        bool IsHaveFreeCell();
        bool IsEnoughParts();
        void StartCraft(CraftObject craftObject);
    }
}
