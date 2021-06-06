using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
// ReSharper disable UnusedMember.Local

#pragma warning disable 649

namespace Assets.Scripts.Ui.FullMenu.Common.Product
{
    [UsedImplicitly]
    public class ProductCell : MonoBehaviour, IProductCell
    {
        [Inject] private readonly IUiController _uiController;

        private IFullMenu _fullMenu;

        public Transform Transform { get; set; }

        [Header("Components")]
        [SerializeField] private Image _icon;
        [SerializeField] private Text _title;
        [SerializeField] private Text _description;

        private void Awake()
        {
            Transform = transform;

            _fullMenu = _uiController.FindByPart("Menu").GetComponent<IFullMenu>();
            _fullMenu.Product = this;
        }

        private void Start()
        {
            SetProductInfo();
        }

        public void SetProductInfo()
        {
            var productData = _fullMenu.ActiveItem.Product;

            SetProductIcon(productData.Icon);
            SetProductTitle(productData.Name);
        }

        private void SetProductIcon(Sprite sprite)
        {
            _icon.sprite = sprite;
        }

        private void SetProductTitle(string title)
        {
            _title.text = title;
        }

        public void SetProductDescription(string text)
        {
            _description.text = text;
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<ProductCell> { }
    }
}
