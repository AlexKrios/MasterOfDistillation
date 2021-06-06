using Assets.Scripts.Ui.FullMenu.Craft.Controller;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Ui.Order.State
{
    public class CraftCellBusy : ICraftCellState
    {
        [Inject(Id = "SceneContext")] private Transform _sceneContext;
        private ICraftController _craftController;
        private readonly CraftCell _craftCell;

        public CraftCellBusy(CraftCell craftCell)
        {
            _craftCell = craftCell;
        }

        public void Enter()
        {
            if (_craftController == null)
            {
                _craftController = _sceneContext.GetComponent<ICraftController>();
            }

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
