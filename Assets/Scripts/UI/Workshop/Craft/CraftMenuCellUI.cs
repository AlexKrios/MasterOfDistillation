using Scripts.Common.Craft;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Workshop.Craft
{
    public class CraftMenuCellUI : MonoBehaviour
    {
        [Inject] private IUiController _uiController;
        [Inject] private ICraftController _craftController;       

        private ProductData _productData;
        public ProductData ProductObject
        {
            get { return _productData; }
            set { _productData = value; }
        }        

        public Image Background;
        public Image Icon;

        [Header("Product info")]
        public Text ProductName;

        public void SetProductInfo(ProductData productData)
        {
            _productData = productData;

            ProductName.text = _productData.ProductName;

            if (_productData.Slug == _craftController.ActiveProduct.Slug)
            {
                SetCellImage(true);
            }
        }

        public void SetCellActive()
        {
            
            SetCellImage(false);                                                        /* Disable past active cell */
            
            _craftController.ActiveProduct = _productData;                              /* Set new active cell */
            _craftController.ProductQuality = ProductQuality.Common;                    /* Reset active product quality */

            SetCellImage(true);                                                         /* Enable current active cell */
        }

        public void SetCellImage(bool active)
        {            
            if (active)
            {
                Background.color = new Color32(255, 155, 90, 255);
            }
            else 
            {
                var activeSlug = _craftController.ActiveProduct.Slug;

                var craftMenuCellList = _uiController.FindByPart("CraftMenu").GetComponent<CraftMenuUI>().CellList;
                var activeCellGO = craftMenuCellList.FirstOrDefault(x => x.Key == activeSlug).Value;
                var activeCell = activeCellGO.GetComponent<CraftMenuCellUI>().Background.GetComponent<Image>();

                activeCell.color = new Color32(255, 255, 255, 255);
            }
        }

        public class Factory : PlaceholderFactory<Transform, CraftMenuCellUI> { }
    }

    public class CraftMenuCellUIFactory : IFactory<Transform, CraftMenuCellUI> 
    {
        private DiContainer _container;

        public CraftMenuCellUIFactory(DiContainer container)
        {
            _container = container;
        }

        public CraftMenuCellUI Create(Transform parent)
        {
            var prefab = Resources.Load("UI/Workshop/Craft/Cell");
            var craftMenuCell = _container.InstantiatePrefabForComponent<CraftMenuCellUI>(prefab, parent);

            return craftMenuCell;
        }
    }
}
