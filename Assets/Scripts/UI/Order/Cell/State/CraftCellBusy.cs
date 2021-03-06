﻿using Assets.Scripts.Controllers.Craft;
using Assets.Scripts.Ui.Order.State;
using Zenject;

namespace Assets.Scripts.Ui.Order.Cell.State
{
    public class CraftCellBusy : ICraftCellState
    {
        [Inject(Id = "SceneContext")] private readonly ICraftController _craftController;
        private readonly CraftCell _craftCell;

        public CraftCellBusy(CraftCell craftCell)
        {
            _craftCell = craftCell;
        }

        public void Enter()
        {
            SetCraftCellInfo();
        }

        public void Click() { }

        public void Exit() { }

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

        public class Factory : PlaceholderFactory<CraftCell, CraftCellBusy> { }
    }
}
