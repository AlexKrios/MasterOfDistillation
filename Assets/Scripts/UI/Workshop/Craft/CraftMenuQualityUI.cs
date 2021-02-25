using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Workshop.Craft
{
    public class CraftMenuQualityUI : MonoBehaviour
    {
        public Image icon;

        private CraftMenuCellUI _parentScript;
        private ProductQuality _productQuality;

        private void Start()
        {
            _parentScript = transform.parent.GetComponent<CraftMenuCellUI>();
            icon.color = new Color32(0, 0, 0, 0);
        }

        public void ChangeProductQuality()
        {
            _productQuality = (ProductQuality)Enum.Parse(typeof(ProductQuality), _parentScript.ProductObject.Quality);
            var intQuality = (int)_productQuality;
            _productQuality = (ProductQuality)intQuality + 1;

            if (!Enum.IsDefined(typeof(ProductQuality), _productQuality)) 
            {
                _productQuality = ProductQuality.Common;
            }

            _parentScript.ProductObject.Quality = _productQuality.ToString();
            ChangeProductQualityIcon();            
        }

        public void ChangeProductQualityIcon()
        {
            if (_productQuality == ProductQuality.Common)
            {
                icon.color = new Color32(200, 200, 200, 0);
            }
            if (_productQuality == ProductQuality.Bronze)
            {
                icon.color = new Color32(150, 150, 150, 255);
            }
            if (_productQuality == ProductQuality.Silver)
            {
                icon.color = new Color32(100, 100, 100, 255);
            }
            if (_productQuality == ProductQuality.Gold)
            {
                icon.color = new Color32(50, 50, 50, 255);
            }
        }
    }
}
