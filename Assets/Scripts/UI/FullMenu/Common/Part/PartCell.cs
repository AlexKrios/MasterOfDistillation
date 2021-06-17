using Assets.Scripts.Stores;
using Assets.Scripts.Stores.Product;
using Assets.Scripts.Stores.Product.Recipe;
using Assets.Scripts.Stores.Raw;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

// ReSharper disable UnusedMember.Local
#pragma warning disable 649

namespace Assets.Scripts.Ui.FullMenu.Common.Part
{
    [UsedImplicitly]
    public class PartCell : MonoBehaviour
    {
        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly IRawStore _rawStore;
        [Inject] private readonly IProductStore _productStore;

        private IFullMenu _fullMenu;
        private IPartGroup _partGroup;
        private int _id;

        [Header("Components")]
        private Image _background;
        [SerializeField] private Image _icon;
        [SerializeField] private Text _count;

        private void Awake()
        {
            _fullMenu = _uiController.FindByPart("Menu").GetComponent<IFullMenu>();
            _partGroup = _fullMenu.Parts;
            _partGroup.SubscribeTabToList(this);

            _background = GetComponent<Image>();
        }

        public void SetPartInfo(RecipeScriptable recipe)
        {
            if (_id <= recipe.Parts.Count)
            {
                var storeCount = GetStoreCount(recipe);

                SetPartIcon(recipe.Parts[_id - 1].Data.Icon, 1f);
                SetPartText($"{storeCount}/{recipe.Parts[_id - 1].Count}");
            }
            else
            {
                ResetPartInfo();
            }
        }

        private int GetStoreCount(RecipeScriptable recipe)
        {
            var dataName = recipe.Parts[_id - 1].Data.Name;
            var type = recipe.Parts[_id - 1].Data.ItemType;

            switch (type)
            {
                case ItemType.Raw:
                    return _rawStore.RawData[dataName].Count;

                default:
                    return _productStore.ItemsDictionary[dataName].Count[(int)recipe.Quality];
            }
        }

        private void ResetPartInfo()
        {
            SetPartIcon(null, 0f);
            SetPartText(null);
        }

        public void SetCellId(int id)
        {
            _id = id;
        }

        public void SetCellParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        // ReSharper disable once UnusedMember.Local
        private void SetPartBackground(Sprite background)
        {
            _background.sprite = background;
        }

        private void SetPartIcon(Sprite icon, float alpha)
        {
            _icon.sprite = icon;
            _icon.color = new Color(1, 1, 1, alpha);
        }

        private void SetPartText(string text)
        {
            _count.text = text;
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<PartCell> { }
    }
}
