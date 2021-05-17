using Assets.Scripts.Common.Craft.Action;
using Assets.Scripts.Objects.Item;
using Assets.Scripts.Objects.Item.Craft;
using Assets.Scripts.Objects.Item.Recipe;
using Assets.Scripts.Scriptable;
using Assets.Scripts.Stores.Level;
using Assets.Scripts.Stores.Product;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Craft;
using Assets.Scripts.UI.Craft.Order;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Common.Craft
{
    [UsedImplicitly]
    public class CraftController : MonoBehaviour, ICraftController
    {
        [Inject] private readonly CraftMenuUiFactory.Settings _craftMenuSettings;
        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly ILevelStore _levelStore;
        [Inject] private readonly IProductStore _productStore;
        [Inject] private readonly List<ICraftPartAction> _craftPartActionList;

        public Dictionary<int, CraftObject> CraftList { get; private set; }

        private CraftCellsGroup _craftCellsGroup;

        private int _currentIndex;
        private RecipeScriptable _recipe;
        private ICraftPartAction _action;

        [Inject]
        private void Construct([Inject(Id = "CraftOrder")] CraftCellsGroup craftOrder)
        {
            _craftCellsGroup = craftOrder;
        }

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            CraftList = new Dictionary<int, CraftObject>();
        }

        public bool IsHaveFreeCell()
        {
            var craftCells = _craftCellsGroup.Cells;

            for (var i = 0; i < craftCells.Count; i++)
            {
                if (craftCells[i].IsBusy)
                {
                    continue;
                }

                craftCells[i].IsBusy = true;
                _currentIndex = i;
                return true;
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
            switch (partObj.Data.ItemType)
            {
                case ItemType.Component:
                    return _craftPartActionList[1];

                default:
                    return _craftPartActionList[0];
            }
        }        

        public IEnumerator StartCraftTimer()
        {
            var currentCraftCell = _craftCellsGroup.Cells[_currentIndex];
            Debug.Log(currentCraftCell);

            var countdownValue = _recipe.CraftTime;
            while (countdownValue > 0)
            {
                yield return new WaitForSeconds(1.0f);
                countdownValue--;
                currentCraftCell.SetCellTimer(countdownValue.ToString());
            }

            Debug.Log(currentCraftCell);
            currentCraftCell.SetCellTimer("Готово");
            currentCraftCell.IsComplete = true;
        }

        public void StartCraft(CraftObject craftObject)
        {
            var timer = StartCoroutine(StartCraftTimer());
            craftObject.Timer = timer;

            CraftList.Add(_currentIndex, craftObject);
            RemoveParts();

            SetCraftCellInfo();
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
            var craftItemIcon = craftItem.Icon;            
            var craftTime = craftItem.Recipes[(int)craftQuality].CraftTime;

            currentCraftCell.SetCellIcon(craftItemIcon);
            currentCraftCell.SetCellTimer(craftTime.ToString());
        }

        public void CompleteCraft(int index)
        {
            var itemCraft = CraftList[index].Item;
            var itemQuality = CraftList[index].Quality;

            _productStore.Store[itemCraft.Name].Count[(int)itemQuality]++;
            _levelStore.Experience += 10 * ((int)itemQuality + 1);
            //_productStore.SetProductExperience(itemCraft.Data.Name);

            Debug.Log($"Craft {itemCraft.Name} complete");

            CraftList.Remove(index);

            _craftCellsGroup.Cells[_currentIndex].IsBusy = false;
            _craftCellsGroup.Cells[_currentIndex].IsComplete = false;
        }
    }
}
