using Assets.Scripts.Objects.Item.Craft;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Common.Craft
{
    public interface ICraftController
    {
        Dictionary<int, CraftObject> CraftList { get; }

        bool IsHaveFreeCell();
        bool IsEnoughParts();
        IEnumerator StartCraftTimer();
        void StartCraft(CraftObject craftObject);
    }
}
