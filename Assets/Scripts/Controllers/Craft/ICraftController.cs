using Assets.Scripts.Stores.Craft;
using System.Collections.Generic;

namespace Assets.Scripts.Controllers.Craft
{
    public interface ICraftController
    {
        Dictionary<int, CraftObject> CraftList { get; }

        bool IsHaveFreeCell();
        bool IsEnoughParts();
        void StartCraft(CraftObject craftObject);
    }
}
