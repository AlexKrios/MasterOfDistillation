using Scripts.Objects.Part;
using Scripts.Objects.Product;
using Scripts.Stores.Level;
using Scripts.Stores.Product;
using Scripts.UI;
using Scripts.UI.Craft;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Scripts.Common.Craft.Action
{
    public class CraftAction
    {
        [Inject] private readonly CraftMenuUIFactory.Settings _menuSettings;

        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly ILevelStore _levelStore;        
        [Inject] private readonly ICraftController _craftController;
        [Inject] private readonly IProductStore _productStore;

        [Inject] private readonly List<ICraftPartAction> _craftPartActionList;

        private RecipeObject _recipe;
        private ICraftPartAction _action;        

        public bool IsEnoughParts()
        {
            var menu = _uiController.FindByPart(_menuSettings.Name).GetComponent<CraftMenu>();
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

        public IEnumerator StartCraft(int number)
        {
            RemoveParts();

            var countdownValue = _recipe.CraftTime;
            while (countdownValue > 0)
            {
                yield return new WaitForSeconds(1.0f);
                countdownValue--;
            }

            CompleteCraft(number);
        }

        public void RemoveParts()
        {
            foreach (var partObj in _recipe.Parts)
            {
                _action.Remove(partObj);
            }
        }

        private void CompleteCraft(int number)
        {
            var itemCraft = _craftController.CraftList[number].Item;
            var itemQuality = _craftController.CraftList[number].Quality;
            var store = _productStore.AllStore[itemCraft.Data.SubType.ToString()];

            store[itemCraft.Data.Name].Count[(int)itemQuality]++;
            _levelStore.Experience += 10 * ((int)itemQuality + 1);
            _productStore.SetProductExpirience(itemCraft.Data.Name);

            Debug.Log($"Craft {itemCraft.Data.Name} complete");            

            _craftController.CraftList.Remove(number); 
        }
    }    
}
