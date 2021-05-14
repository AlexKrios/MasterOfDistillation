using Scripts.Objects.Craft;
using Scripts.UI.Craft.Order;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Common.Craft
{
    public class CraftController : ICraftController
    {
        private Dictionary<int, CraftObject> _craftList = new Dictionary<int, CraftObject>();
        public Dictionary<int, CraftObject> CraftList { get => _craftList; }

        private CraftCellsGroup _craftCellsGroup;

        public CraftController()
        {
            _craftCellsGroup = GameObject.Find("CraftOrder").GetComponent<CraftCellsGroup>();
        }

        public int? CheckFreeIndex()
        {
            var craftCells = _craftCellsGroup.Cells;

            for (var i = 0; i < craftCells.Count; i++)
            {
                if (!craftCells[i].IsBusy)
                {
                    craftCells[i].IsBusy = true;
                    return i;
                }
            }

            return null;
        }
    }
}
