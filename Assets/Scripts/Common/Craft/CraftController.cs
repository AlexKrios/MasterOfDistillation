using Scripts.Objects.Craft;
using System.Collections.Generic;

namespace Scripts.Common.Craft
{
    public class CraftController : ICraftController
    {
        private Dictionary<int, CraftObject> _craftList = new Dictionary<int, CraftObject>();
        public Dictionary<int, CraftObject> CraftList { get => _craftList; }

        public int? CheckFreeIndex()
        {
            for (var i = 0; i < 4; i++)
            {
                if (!_craftList.ContainsKey(i))
                {
                    return i;
                }
            }

            return null;
        }
    }
}
