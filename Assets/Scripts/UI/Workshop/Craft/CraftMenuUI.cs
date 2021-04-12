using Scripts.Common.Craft;
using Scripts.Scenes.Main.MainCamera;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop.Craft
{
    public class CraftMenuUI : MonoBehaviour
    {
        public GameObject Container;
        public Dictionary<string, GameObject> CellList = new Dictionary<string, GameObject>();
        public GameObject QualityBtn;

        public class Factory : PlaceholderFactory<ICraft, CraftMenuUI> { }
    }

    public class CraftMenuUIFactory : IFactory<ICraft, CraftMenuUI>
    {
        private DiContainer _container;
        private IUiController _uiController;        
        [Inject] private IDisable _disable;
        [Inject] private ICraftController _craftController;

        [Inject] private CraftMenuCellUI.Factory _craftMenuCellUI;

        private Transform _mainCanvas;

        private ICraft _productCraft;
        private CraftMenuUI _craftMenu;

        private List<ProductData> _items;

        private int _rowCount = 3;
        private int _padding = 25;
        private int _height = 250;

        public CraftMenuUIFactory(DiContainer container, [Inject(Id = "MainCanvas")] RectTransform mainCanvas, IUiController uiController)
        {
            _container = container;
            _uiController = uiController;

            _mainCanvas = mainCanvas.gameObject.transform;
            _items = _uiController.ActiveBuilding.GetComponent<ICraft>().ProductList;
        }

        public CraftMenuUI Create(ICraft productCraft)
        {
            _productCraft = productCraft;

            var name = _productCraft.ProductType + "CraftMenu";
            var uiElementSimilar = _uiController.FindByPart("CraftMenu");

            if (uiElementSimilar != null)
            {
                _uiController.Remove(uiElementSimilar);
                _disable.Remove("CraftMenu");
            }

            var prefab = Resources.Load("UI/Workshop/Craft/Menu");
            _craftMenu = _container.InstantiatePrefabForComponent<CraftMenuUI>(prefab, _mainCanvas);
            _craftMenu.name = name;

            _uiController.Add(_craftMenu.name, _craftMenu.gameObject);
            _disable.Add(name);
            
            SetContainerHeight();
            CreateCraftCell();

            return _craftMenu;
        }

        private void SetContainerHeight() 
        {            
            var rowCount = (int)Math.Floor((double)_items.Count / _rowCount);
            var height = _height * rowCount + _padding * (rowCount - 1);

            var containerRect = _craftMenu.GetComponent<CraftMenuUI>().Container.GetComponent<RectTransform>();
            containerRect.sizeDelta = new Vector2(containerRect.sizeDelta.x, height);
        }

        private void CreateCraftCell()
        {           
            var parent = _craftMenu.GetComponent<CraftMenuUI>().Container.transform;
            var _items = _uiController.ActiveBuilding.GetComponent<ICraft>().ProductList;

            _craftController.ActiveProduct = _items[0];

            for (int i = 0; i < _items.Count; i++)
            {
                var cell = _craftMenuCellUI.Create(parent.transform);
                _craftMenu.CellList.Add(_items[i].Slug, cell.gameObject);
                cell.SetProductInfo(_items[i]);                
                cell.name = _items[i].Slug;                
            }
        }
    }
}
