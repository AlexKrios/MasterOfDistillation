using Assets.Scripts.Ui.Common.ProductMenu;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts.UI.Craft.Part
{
    [UsedImplicitly]
    public class PartGroup : MonoBehaviour
    {
        [SerializeField] private CraftMenu _menu;

        [Header("Links")]
        [SerializeField] private List<PartCell> _parts;
        public List<PartCell> Parts => _parts;

        private IItemButton ActiveItem => _menu.Items.ActiveItem;
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
