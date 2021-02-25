using Scripts.Common.Craft;
using Scripts.Scenes.Main.MainCamera;
using Scripts.Stores.Product;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop.Craft
{
    public class CraftMenuUI : MonoBehaviour
    {
        public GameObject Container;

        public class Factory : PlaceholderFactory<ICraft, CraftMenuUI> { }
    }

    public class CraftMenuUIFactory : IFactory<ICraft, CraftMenuUI>
    {
        private DiContainer _container;
        [Inject] private IUiController _uiController;        
        [Inject] private IRecipesStore _recipesStore;
        [Inject] private IDisable _disable;

        [Inject] private CraftMenuCellUI.Factory _craftMenuCellUI;

        private Transform _mainCanvas;

        private ICraft _productCraft;
        private CraftMenuUI _craftMenu;

        private int _padding = 25;
        private int _height = 125;

        public CraftMenuUIFactory(DiContainer container, [Inject(Id = "MainCanvas")] RectTransform mainCanvas)
        {
            _container = container;

            _mainCanvas = mainCanvas.gameObject.transform;
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
            var itemLength = _recipesStore.FindBySubType(_productCraft.ProductType).Count;
            var height = _height * itemLength + _padding * (itemLength - 1);

            var containerRect = _craftMenu.GetComponent<CraftMenuUI>().Container.GetComponent<RectTransform>();
            containerRect.sizeDelta = new Vector2(containerRect.sizeDelta.x, height);
        }

        private void CreateCraftCell()
        {
            var parent = _craftMenu.GetComponent<CraftMenuUI>().Container.transform;
            var items = _recipesStore.FindBySubType(_productCraft.ProductType);

            for (int i = 0; i < items.Count; i++)
            {
                var cell = _craftMenuCellUI.Create(parent.transform);                
                cell.SetProductInfo(items[i]);
            }
        }
    }
}
