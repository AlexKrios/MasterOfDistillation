using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Objects.Craft;

namespace Assets.Scripts.Common.Craft
{
    public interface ICraftController
    {
        Dictionary<int, CraftObject> CraftList { get; }

        bool IsHaveFreeCell();
        bool IsEnoughParts();
        IEnumerator StartCraftTimer();
        void StartCraft(CraftObject craftObject);
        void CompleteCraft(int index);
    }
}
