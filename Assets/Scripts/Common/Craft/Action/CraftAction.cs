using Scripts.Objects.Product;
using Scripts.Stores;
using Scripts.UI;
using Scripts.UI.Workshop.Craft;
using Scripts.UI.Workshop.Craft.Item;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Scripts.Common.Craft.Action
{
    public class CraftAction
    {
        [Inject] private IUiController _uiController;
        [Inject] private ICraftController _craftController;
        [Inject] private List<IStore> _storeList;

        [Inject] private RawAction _rawAction;

        private CraftMenuUI _menu;

        private ItemButton _activeItem { get => _menu.ItemsGroup.ActiveItem; }
        private ProductQuality _activeQuality { get => _menu.QualityBtn.ActiveQuality; }

        private RecipeObject _recipe;

        public bool IsEnoughParts()
        {
            _menu = _uiController.FindByPart("CraftMenu").GetComponent<CraftMenuUI>();
            _recipe = _activeItem.Product.Recipes.First(x => x.Quality == _activeQuality);

            bool isEnough = true;

            foreach (var partObj in _recipe.Parts) 
            {        
                switch (partObj.Data.Type)
                {
                    case ProductType.Raw:
                        isEnough = _rawAction.IsEnoughRaw(partObj);
                        break;

                    default:
                        return true;
                }

                if (!isEnough)
                {                    
                    return false;
                }
            }

            return isEnough;
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
                switch (partObj.Data.Type)
                {
                    case ProductType.Raw:
                        _rawAction.RemoveRaw(partObj);
                        break;

                    default:
                        break;
                }
            }
        }

        private void CompleteCraft(int number)
        {
            var itemCraft = _craftController.CraftList[number].Item;
            var itemQuality = _craftController.CraftList[number].Quality;
            var store = _storeList[0].AllStore[itemCraft.Data.SubType.ToString()];
            var itemStore = store[itemCraft.Data.Name];
            
            itemStore.Count[(int)itemQuality]++;

            Debug.Log($"Craft {itemCraft.Data.Name} complete");            

            _craftController.CraftList.Remove(number);
        }
    }    
}
