using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI.Craft.Item;
using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts.UI.Craft.Part
{
    public class PartGroup : MonoBehaviour
    {
        [SerializeField] private CraftMenu _menu;

        [Header("Links")]
        [SerializeField] private List<PartCell> _parts;
        public List<PartCell> Parts => _parts;

        private ItemButton ActiveItem => _menu.ItemsGroup.ActiveItem;
        private ProductQuality ActiveQuality => _menu.QualityBtn.ActiveQuality;

        // ReSharper disable once UnusedMember.Local
        private void Start() { }

        public void SetPartsInfo()
        {            
            var recipe = ActiveItem.Product.Recipes.First(x => x.Quality == ActiveQuality);

            for (var i = 0; i < _menu.PartGroup.Parts.Count; i++)
            {
                _parts[i].SetPartInfo(recipe);
            }            
        }
    }
}
