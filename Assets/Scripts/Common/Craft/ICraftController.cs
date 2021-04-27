using Scripts.Objects.Craft;
using System.Collections.Generic;

namespace Scripts.Common.Craft
{
    public interface ICraftController
    {
        Dictionary<int, CraftObject> CraftList { get; }

        int? CheckFreeIndex();
    }
}
