using Scripts.Common.Craft;
using Scripts.Objects.Product;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Workshop.Craft
{
    public class CraftMenuCellUI : MonoBehaviour
    {
        [Inject] private IUiController _uiController;
        [Inject] private ICraftController _craftController;

        public GameObject icon;
        public GameObject product;
        public GameObject quality;

        private ProductObject _productObject;
        public ProductObject ProductObject
        {
            get { return _productObject; }
            set { _productObject = value; }
        }

        [Header("Product info")]
        public Text productName;
        public Text productType;

        public void SetProductInfo(ProductObject productObject)
        {
            _productObject = productObject;
            _productObject.Quality = "Common";

            productName.text = _productObject.Name;
            productType.text = $"{_productObject.Type}/{_productObject.SubType}";
        }

        public void SetProduct()
        {
            _craftController.ActiveProduct = _productObject;
        }

        public void StartProduction()
        {
            _uiController.ActiveBuilding.GetComponent<ICraft>().CraftComponent();
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
            craftMenuCell.name = "Cell";

            return craftMenuCell;
        }
    }
}
