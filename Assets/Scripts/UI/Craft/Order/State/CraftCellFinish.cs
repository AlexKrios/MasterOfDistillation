using Assets.Scripts.Common.Craft;
using Assets.Scripts.Stores.Level;
using Assets.Scripts.Stores.Product;
using Assets.Scripts.UI.Craft.Order;
using UnityEngine;

namespace Assets.Scripts.Ui.Craft.Order.State
{
    public class CraftCellFinish : ICraftCellState
    {
        private readonly CraftCell _craftCell;

        private readonly ICraftController _craftController;
        private readonly ILevelStore _levelStore;
        private readonly IProductStore _productStore;

        public CraftCellFinish(CraftCell craftCell)
        {
            _craftCell = craftCell;

            _craftController = craftCell.CraftController;
            _levelStore = craftCell.LevelStore;
            _productStore = craftCell.ProductStore;
        }

        public void Enter()
        {
            Debug.Log("Enter Finish");

            _craftCell.SetCellTimer("Готово");
        }

        public void Click()
        {
            Debug.Log("Click Finish");

            CompleteCraft();

            _craftCell.SetStateEmpty();
        }

        public void Exit()
        {
            Debug.Log("Exit Finish");
        }

        private void CompleteCraft()
        {
            var craftList = _craftController.CraftList;

            var itemCraft = craftList[_craftCell.Id].Item;
            var itemQuality = craftList[_craftCell.Id].Quality;

            _productStore.Store[itemCraft.Name].Count[(int)itemQuality]++;
            _levelStore.Experience += 10 * ((int)itemQuality + 1);
            //_craftCell.ProductStore.SetProductExperience(itemCraft.Name);

            Debug.Log($"Craft {itemCraft.Name} complete");

            craftList.Remove(_craftCell.Id);

            _craftCell.ResetCell();
        }

        //private void SetCraftCellInfo()
        //{
        //    var craftObj = _craftController.CraftList[_craftCell.Id];

        //    var craftItem = craftObj.Item;
        //    var craftQuality = craftObj.Quality;
        //    var craftItemIcon = craftItem.Icon;
        //    var craftTime = craftItem.Recipes[(int)craftQuality].CraftTime;

        //    _craftCell.SetCellIcon(craftItemIcon);
        //    _craftCell.SetCellTimer(craftTime.ToString());
        //}
    }
}
