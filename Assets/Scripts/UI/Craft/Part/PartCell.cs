using Assets.Scripts.Objects.Item;
using Assets.Scripts.Scriptable;
using Assets.Scripts.Stores.Product;
using Assets.Scripts.Stores.Raw;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
#pragma warning disable 649

namespace Assets.Scripts.UI.Craft.Part
{
    [UsedImplicitly]
    public class PartCell : MonoBehaviour
    {        
        [Inject] private readonly IRawStore _rawStore;
        [Inject] private readonly IProductStore _productStore;

        [Header("System")]
        [SerializeField] private int _id;

        [Header("Components")]
        [SerializeField] private Image _background;
        [SerializeField] private Image _icon;
        [SerializeField] private Text _count;

        public void SetPartInfo(RecipeScriptable recipe)
        {
            if (_id <= recipe.Parts.Count)
            {
                var storeCount = GetStoreCount(recipe);

                Debug.Log(recipe.Parts[_id - 1].Data.Name);

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
                    return _productStore.Store[dataName].Count[(int)recipe.Quality];
            }
        }

        private void ResetPartInfo()
        {
            SetPartIcon(null, 0f);
            SetPartText(null);
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
    }
}
