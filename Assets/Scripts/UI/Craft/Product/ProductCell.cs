using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 649

namespace Assets.Scripts.UI.Craft.Product
{
    public class ProductCell : MonoBehaviour
    {
        [Header("Components")]
        private Image _background;
        [SerializeField] private Image _icon;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            _background = GetComponent<Image>();
        }

        public void SetProductBackground(Sprite background)
        {
            _background.sprite = background;
        }

        public void SetProductIcon(Sprite icon)
        {
            _icon.sprite = icon;
        }
    }
}
