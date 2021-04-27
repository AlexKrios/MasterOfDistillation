using Scripts.UI.Workshop.Craft.Item;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.UI.Workshop.Craft.Part
{
    public class PartGroup : MonoBehaviour
    {
        [SerializeField] private CraftMenuUI _menu;

        [Header("Links")]
        [SerializeField] private List<PartCell> _parts;
        public List<PartCell> Parts { get => _parts; }

        private ItemButton _activeItem { get => _menu.ItemsGroup.ActiveItem; }
        private ProductQuality _activeQuality { get => _menu.QualityBtn.ActiveQuality; }

        private void Start() { }

        public void SetPartsInfo()
        {            
            var recipe = _activeItem.Product.Recipes.First(x => x.Quality == _activeQuality);

            for (var i = 0; i < _menu.PartGroup.Parts.Count; i++)
            {
                _parts[i].SetPartInfo(recipe);
            }            
        }
    }
}
