using Assets.Scripts.Stores.Level;
using Assets.Scripts.Stores.Product;
using Assets.Scripts.Ui.FullMenu.Craft.Controller;
using Assets.Scripts.Ui.Order.Result;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Ui.Order.State
{
    public class CraftCellFinish : ICraftCellState
    {
        [Inject] private readonly ResultCanvas.Factory _craftResultFactory;

        [Inject] private readonly ILevelStore _levelStore;
        [Inject] private readonly IProductStore _productStore;

        [Inject] private readonly ProductLevelStore _productLevelStore;

        [Inject(Id = "SceneContext")] private Transform _sceneContext;
        private ICraftController _craftController;
        private readonly CraftCell _craftCell;

        public CraftCellFinish(CraftCell craftCell)
        {
            _craftCell = craftCell;
        }

        public void Enter()
        {
            if (_craftController == null)
            {
                _craftController = _sceneContext.GetComponent<ICraftController>();
            }

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

            _productStore.ItemsDictionary[itemCraft.Name].Count[(int)itemQuality]++;
            _levelStore.OnSetExperience.Invoke(10 * ((int)itemQuality + 1));
            //_craftCell.ProductStore.SetProductExperience(itemCraft.Name);

            _productLevelStore.OnSetExperience.Invoke(_productStore.ItemsDictionary[itemCraft.Name]);

            //Debug.Log($"Craft {itemCraft.Name} complete");

            craftList.Remove(_craftCell.Id);

            _craftCell.ResetCell();
        }

        public class Factory : PlaceholderFactory<CraftCell, CraftCellFinish> { }
    }
}
