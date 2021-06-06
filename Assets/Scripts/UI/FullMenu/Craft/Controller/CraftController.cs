using Assets.Scripts.Objects.Item;
using Assets.Scripts.Objects.Item.Craft;
using Assets.Scripts.Scriptable;
using Assets.Scripts.Ui.FullMenu.Craft.Controller.Action;
using Assets.Scripts.Ui.Order;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Ui.FullMenu.Common;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Ui.FullMenu.Craft.Controller
{
    [UsedImplicitly]
    public class CraftController : MonoBehaviour, ICraftController
    {
        [Inject] private readonly CraftMenuFactory.Settings _craftMenuSettings;
        [Inject] private readonly CraftGroupFactory.Settings _craftGroupSettings;
        [Inject] private readonly IUiController _uiController;

        [Inject] private readonly List<ICraftPartAction> _craftPartActionList;
        private Dictionary<ItemType, ICraftPartAction> _actionDictionary;

        public int CraftCellCount { get; set; }
        public Dictionary<int, CraftObject> CraftList { get; private set; }

        private CraftGroup _craftGroup;

        private int _currentIndex;
        private RecipeScriptable _recipe;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            CraftList = new Dictionary<int, CraftObject>();
            CraftCellCount = 2;

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
            if (_craftGroup == null)
                _craftGroup = _uiController.Find(_craftGroupSettings.Name).GetComponent<CraftGroup>();

            var menu = _uiController.Find(_craftMenuSettings.Name).GetComponent<IFullMenu>();
            var activeItem = menu.ActiveItem;
            var activeQuality = menu.ActiveQuality;

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
            var craftCells = _craftGroup.Cells;
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

            _craftGroup.Cells[_currentIndex].SetStateBusy();
        }

        private IEnumerator StartCraftTimer()
        {
            var currentCraftCell = _craftGroup.Cells[_currentIndex];

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
