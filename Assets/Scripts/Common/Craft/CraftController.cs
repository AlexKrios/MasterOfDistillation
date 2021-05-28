using Assets.Scripts.Common.Craft.Action;
using Assets.Scripts.Objects.Item;
using Assets.Scripts.Objects.Item.Craft;
using Assets.Scripts.Scriptable;
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
        [Inject] private readonly List<ICraftPartAction> _craftPartActionList;
        private Dictionary<ItemType, ICraftPartAction> _actionDictionary;

        public Dictionary<int, CraftObject> CraftList { get; private set; }

        private CraftCellsGroup _craftCellsGroup;

        private int _currentIndex;
        private RecipeScriptable _recipe;

        [Inject]
        private void Construct([Inject(Id = "CraftOrder")] CraftCellsGroup craftOrder)
        {
            _craftCellsGroup = craftOrder;
        }

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            CraftList = new Dictionary<int, CraftObject>();

            InitDictionary();
        }

        private void InitDictionary()
        {
            _actionDictionary = new Dictionary<ItemType, ICraftPartAction>();

            for (var i = 0; i < _craftPartActionList.Count; i++)
            {
                _actionDictionary.Add((ItemType)i, _craftPartActionList[i]);
            }
        }

        public bool IsEnoughParts()
        {
            var menu = _uiController.FindByPart(_craftMenuSettings.Name).GetComponent<CraftMenu>();
            var activeItem = menu.Items.ActiveItem;
            var activeQuality = menu.QualityBtn.ActiveQuality;

            _recipe = activeItem.Product.Recipes.First(x => x.Quality == activeQuality);

            foreach (var partObj in _recipe.Parts)
            {
                var actionType = partObj.Data.ItemType;
                var isEnough = _actionDictionary[actionType].IsEnough(partObj);

                if (!isEnough) { return false; }
            }

            return true;
        }

        public bool IsHaveFreeCell()
        {
            var craftCells = _craftCellsGroup.Cells;

            for (var i = 0; i < craftCells.Count; i++)
            {
                if (!craftCells[i].IsFreeForCraft())
                {
                    continue;
                }

                _currentIndex = i;
                return true;
            }            

            return false;
        }

        public void StartCraft(CraftObject craftObject)
        {
            var timer = StartCoroutine(StartCraftTimer());
            craftObject.Timer = timer;

            CraftList.Add(_currentIndex, craftObject);
            RemoveParts();

            _craftCellsGroup.Cells[_currentIndex].SetStateBusy();
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

            currentCraftCell.SetStateFinish();
        }

        private void RemoveParts()
        {
            foreach (var partObj in _recipe.Parts)
            {
                var actionType = partObj.Data.ItemType;
                _actionDictionary[actionType].Remove(partObj);
            }
        }
    }
}
