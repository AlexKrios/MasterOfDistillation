using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

// ReSharper disable UnusedMember.Local

#pragma warning disable 649

namespace Assets.Scripts.Ui.FullMenu.Common.Part
{
    [UsedImplicitly]
    public class PartGroup : MonoBehaviour, IPartGroup
    {
        [Inject] private readonly PartCell.Factory _partCellFactory;

        [Inject] private readonly IUiController _uiController;

        private IFullMenu _fullMenu;
        private List<PartCell> _parts;

        private void Awake()
        {
            _fullMenu = _uiController.FindByPart("Menu").GetComponent<IFullMenu>();
            _fullMenu.Parts = this;

            InitParts();
        }

        private void Start()
        {
            SetPartsInfo();
        }

        private void InitParts()
        {
            for (var i = 1; i <= 4; i++)
            {
                var part = _partCellFactory.Create();
                part.gameObject.name = $"Part{i}";
                part.SetCellId(i);
                part.SetCellParent(transform);
            }
        }

        public void SubscribeTabToList(PartCell cell)
        {
            if (_parts == null) 
                _parts = new List<PartCell>();

            _parts.Add(cell);
        }

        public void SetPartsInfo()
        {
            var activeItemRecipes = _fullMenu.ActiveItem.Product.Recipes;
            var activeQuality = _fullMenu.ActiveQuality;

            var recipe = activeItemRecipes.First(x => x.Quality == activeQuality);

            foreach (var part in _parts)
                part.SetPartInfo(recipe);
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<PartGroup> { }
    }
}
