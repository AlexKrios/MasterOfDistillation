using Scripts.Common.Craft.Action;
using Scripts.Objects.Craft;
using Scripts.Objects.Part;
using Scripts.Objects.Product;
using Scripts.Stores.Level;
using Scripts.Stores.Product;
using Scripts.UI;
using Scripts.UI.Craft;
using Scripts.UI.Craft.Order;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Scripts.Common.Craft
{
    public class CraftController : MonoBehaviour, ICraftController
    {
        [Inject] private readonly CraftMenuUIFactory.Settings _craftMenuSettings;
        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly ILevelStore _levelStore;
        [Inject] private readonly IProductStore _productStore;
        [Inject] private readonly List<ICraftPartAction> _craftPartActionList;

        public Dictionary<int, CraftObject> CraftList { get; private set; }

        private CraftCellsGroup _craftCellsGroup;

        private int _currentIndex;
        private RecipeObject _recipe;
        private ICraftPartAction _action;

        [Inject]
        private void Construct([Inject(Id = "CraftOrder")] CraftCellsGroup craftOrder)
        {
            _craftCellsGroup = craftOrder;
        }

        private void Start()
        {
            CraftList = new Dictionary<int, CraftObject>();
        }

        public bool IsHaveFreeCell()
        {
            var craftCells = _craftCellsGroup.Cells;

            for (var i = 0; i < craftCells.Count; i++)
            {
                if (!craftCells[i].IsBusy)
                {
                    craftCells[i].IsBusy = true;
                    _currentIndex = i;
                    return true;
                }
            }

            return false;
        }

        public bool IsEnoughParts()
        {
            var menu = _uiController.FindByPart(_craftMenuSettings.Name).GetComponent<CraftMenu>();
            var activeItem = menu.ItemsGroup.ActiveItem;
            var activeQuality = menu.QualityBtn.ActiveQuality;

            _recipe = activeItem.Product.Recipes.First(x => x.Quality == activeQuality);

            foreach (var partObj in _recipe.Parts)
            {
                _action = SetActionType(partObj);
                var isEnough = _action.IsEnough(partObj);

                if (!isEnough)
                {
                    return false;
                }
            }

            return true;
        }

        private ICraftPartAction SetActionType(PartObject partObj)
        {
            switch (partObj.Data.Type)
            {
                case ProductType.Component:
                    return _craftPartActionList[1];

                default:
                    return _craftPartActionList[0];
            }
        }        

        public IEnumerator StartCraftTimer()
        {
            var currentCraftCell = _craftCellsGroup.Cells[_currentIndex];

            var countdownValue = _recipe.CraftTime;
            while (countdownValue > 0)
            {
                yield return new WaitForSeconds(1.0f);
                countdownValue--;
                currentCraftCell.SetCellTimer(countdownValue.ToString());
            }

            currentCraftCell.SetCellTimer("Готово");
            currentCraftCell.IsComplete = true;
        }

        public void StartCraft(CraftObject craftObject)
        {
            CraftList.Add(_currentIndex, craftObject);
            RemoveParts();

            SetCraftCellInfo();

            //CompleteCraft(number);
        }

        private void RemoveParts()
        {
            foreach (var partObj in _recipe.Parts)
            {
                _action.Remove(partObj);
            }
        }

        private void SetCraftCellInfo()
        {
            var currentCraftCell = _craftCellsGroup.Cells[_currentIndex];

            var craftItem = CraftList[_currentIndex].Item;
            var craftQuality = CraftList[_currentIndex].Quality;
            var craftItemIcon = craftItem.Data.Icon;            
            var craftTime = craftItem.Recipes[(int)craftQuality].CraftTime;

            currentCraftCell.SetCellIcon(craftItemIcon);
            currentCraftCell.SetCellTimer(craftTime.ToString());
        }

        public void CompleteCraft(int index)
        {
            var itemCraft = CraftList[index].Item;
            var itemQuality = CraftList[index].Quality;
            var store = _productStore.AllStore[itemCraft.Data.SubType.ToString()];

            store[itemCraft.Data.Name].Count[(int)itemQuality]++;
            _levelStore.Experience += 10 * ((int)itemQuality + 1);
            _productStore.SetProductExpirience(itemCraft.Data.Name);

            Debug.Log($"Craft {itemCraft.Data.Name} complete");

            CraftList.Remove(index);

            _craftCellsGroup.Cells[_currentIndex].IsBusy = false;
            _craftCellsGroup.Cells[_currentIndex].IsComplete = false;
        }
    }
}
