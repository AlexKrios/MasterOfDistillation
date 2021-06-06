using Assets.Scripts.Ui.FullMenu.Common;
using Assets.Scripts.Ui.FullMenu.Common.Item;
using Assets.Scripts.Ui.FullMenu.Common.Model;
using Assets.Scripts.Ui.FullMenu.Common.Part;
using Assets.Scripts.Ui.FullMenu.Common.Product;
using Assets.Scripts.Ui.FullMenu.Common.Quality;
using Assets.Scripts.Ui.FullMenu.Common.Tab;
using Assets.Scripts.Ui.FullMenu.Craft.Create;
using Assets.Scripts.Ui.FullMenu.Craft.Item;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

// ReSharper disable UnusedMember.Local
#pragma warning disable 649

namespace Assets.Scripts.Ui.FullMenu.Craft
{
    [UsedImplicitly]
    public class CraftMenu : MonoBehaviour, IFullMenu
    {
        [Inject] private readonly CraftMenuFactory.Settings _craftMenuSettings;

        [Inject] private readonly IUiController _uiController;

        [Inject] private readonly TabsGroup.Factory _typeTabsFactory;
        [Inject] private readonly ItemsGroup.Factory _itemGroupFactory;

        [Inject] private readonly ProductCell.Factory _productCellFactory;
        [Inject] private readonly PartGroup.Factory _partGroupFactory;
        [Inject] private readonly CreateButton.Factory _createButtonFactory;
        [Inject] private readonly QualityButton.Factory _qualityButtonFactory;

        [Inject] private readonly ModelGroup.Factory _modelGroupFactory;

        public GameObject GameObject { get; private set; }

        public ITabButton ActiveTab { get; set; }
        public IItemButton ActiveItem { get; set; }
        public ProductQuality ActiveQuality { get; set; }

        public ITabsGroup Tabs { get; set; }
        public IItemsGroup Items { get; set; }

        public IProductCell Product { get; set; }
        public IPartGroup Parts { get; set; }
        public IQualityButton Quality { get; set; }

        public IModelGroup Model { get; set; }

        private void Awake()
        {
            GameObject = gameObject;

            gameObject.name = _craftMenuSettings.Name;
            _uiController.Add(gameObject.name, gameObject);

            _typeTabsFactory.Create();
            _itemGroupFactory.Create();

            _productCellFactory.Create();
            _partGroupFactory.Create();
            _createButtonFactory.Create();
            _qualityButtonFactory.Create();

            _modelGroupFactory.Create();
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<CraftMenu> { }
    }
}
