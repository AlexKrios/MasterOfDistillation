using Assets.Scripts.Common.Craft;
using Assets.Scripts.UI.Craft.Order;
using UnityEngine;

namespace Assets.Scripts.Ui.Craft.Order.State
{
    public class CraftCellBusy : ICraftCellState
    {
        private readonly ICraftController _craftController;

        private readonly CraftCell _craftCell;

        public CraftCellBusy(CraftCell craftCell)
        {
            _craftCell = craftCell;

            _craftController = craftCell.CraftController;
        }

        public void Enter()
        {
            Debug.Log("Enter Busy");

            SetCraftCellInfo();
        }

        public void Click()
        {
            Debug.Log("Click Busy");
        }

        public void Exit()
        {
            Debug.Log("Exit Busy");
        }

        private void SetCraftCellInfo()
        {
            var craftObj = _craftController.CraftList[_craftCell.Id];

            var craftItem = craftObj.Item;
            var craftQuality = craftObj.Quality;
            var craftItemIcon = craftItem.Icon;
            var craftTime = craftItem.Recipes[(int)craftQuality].CraftTime;

            _craftCell.SetCellIcon(craftItemIcon);
            _craftCell.SetCellTimer(craftTime.ToString());
        }
    }
}
