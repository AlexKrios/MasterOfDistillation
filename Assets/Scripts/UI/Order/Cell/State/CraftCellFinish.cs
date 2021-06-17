using Assets.Scripts.Controllers.Craft;
using Assets.Scripts.Controllers.Product;
using Assets.Scripts.Stores.Level;
using Assets.Scripts.Ui.Order.Result;
using Assets.Scripts.Ui.Order.State;
using Zenject;

namespace Assets.Scripts.Ui.Order.Cell.State
{
    public class CraftCellFinish : ICraftCellState
    {
        [Inject] private readonly ResultCanvas.Factory _craftResultFactory;

        [Inject] private readonly ILevelStore _levelStore;

        [Inject] private readonly ProductCountController _productCountController;
        [Inject] private readonly ProductLevelController _productLevelController;

        [Inject(Id = "SceneContext")] private readonly ICraftController _craftController;
        private readonly CraftCell _craftCell;

        public CraftCellFinish(CraftCell craftCell)
        {
            _craftCell = craftCell;
        }

        public void Enter()
        {
            _craftCell.SetCellTimer("Готово");
        }

        public void Click()
        {
            var craftItem = _craftController.CraftList[_craftCell.Id];

            CompleteCraft();
            _craftResultFactory.Create(craftItem);

            _craftCell.SetStateEmpty();
        }

        public void Exit() { }

        private void CompleteCraft()
        {
            var craftList = _craftController.CraftList;

            var itemCraft = craftList[_craftCell.Id].Item;
            var itemQuality = craftList[_craftCell.Id].Quality;

            _levelStore.OnSetExperience.Invoke(10 * ((int)itemQuality + 1));

            _productCountController.OnSetCount.Invoke(itemCraft, itemQuality);
            _productLevelController.OnSetExperience.Invoke(itemCraft);

            //Debug.Log($"Craft {itemCraft.Name} complete");

            craftList.Remove(_craftCell.Id);

            _craftCell.ResetCell();
        }

        public class Factory : PlaceholderFactory<CraftCell, CraftCellFinish> { }
    }
}
