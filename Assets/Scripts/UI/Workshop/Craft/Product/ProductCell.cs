using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Workshop.Craft.Product
{
    public class ProductCell : MonoBehaviour
    {
        [Header("Components")]
        private Image _background;
        [SerializeField] private Image _icon;

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
