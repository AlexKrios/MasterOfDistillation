using Scripts.Objects.Product;
using Scripts.Stores;
using Scripts.Stores.Level;
using Scripts.UI;
using Scripts.UI.Workshop.Craft;
using Scripts.UI.Workshop.Craft.Item;
using System.Collections;
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
        [Inject] private readonly IStore _productStore;

        [Inject] private readonly RawAction _rawAction;
        [Inject] private readonly ComponentAction _craftAction;

        private CraftMenuUI _menu;

        private ItemButton ActiveItem { get => _menu.ItemsGroup.ActiveItem; }
        private ProductQuality ActiveQuality { get => _menu.QualityBtn.ActiveQuality; }

        private RecipeObject _recipe;

        public bool IsEnoughParts()
        {
            _menu = _uiController.FindByPart(_menuSettings.Name).GetComponent<CraftMenuUI>();
            _recipe = ActiveItem.Product.Recipes.First(x => x.Quality == ActiveQuality);

            bool isEnough = true;

            foreach (var partObj in _recipe.Parts) 
            {        
                switch (partObj.Data.Type)
                {
                    case ProductType.Raw:
                        isEnough = _rawAction.IsEnoughRaw(partObj);
                        break;

                    case ProductType.Component:
                        isEnough = _craftAction.IsEnoughComponents(partObj);
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

                    case ProductType.Component:
                        _craftAction.RemoveComponents(partObj);
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
            var store = _productStore.AllStore[itemCraft.Data.SubType.ToString()];

            store[itemCraft.Data.Name].Count[(int)itemQuality]++;
            _levelStore.Experience += 10 * ((int)itemQuality + 1);

            Debug.Log($"Craft {itemCraft.Data.Name} complete");            

            _craftController.CraftList.Remove(number); 
        }
    }    
}
