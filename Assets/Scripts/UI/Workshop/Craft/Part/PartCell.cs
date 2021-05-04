using Scripts.Objects.Product;
using Scripts.Stores;
using Scripts.Stores.Raw;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Workshop.Craft.Part
{
    public class PartCell : MonoBehaviour
    {        
        [Inject] private IRawStore _rawStore;
        [Inject] private IStore _store;

        [Header("System")]
        [SerializeField] private int _id;

        [Header("Components")]
        [SerializeField] private Image _background;
        [SerializeField] private Image _icon;
        [SerializeField] private Text _count;

        public void SetPartInfo(RecipeObject recipe)
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

        private int GetStoreCount(RecipeObject recipe)
        {
            var name = recipe.Parts[_id - 1].Data.Name;
            var type = recipe.Parts[_id - 1].Data.Type;
            var subType = recipe.Parts[_id - 1].Data.SubType;

            switch (type)
            {
                case ProductType.Raw:
                    return _rawStore.RawData[name].Count;

                default:
                    var store = _store.AllStore[subType.ToString()];
                    return store[name].Count[(int)recipe.Quality];
            }
        }

        private void ResetPartInfo()
        {
            SetPartIcon(null, 0f);
            SetPartText(null);
        }

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
    }
}
