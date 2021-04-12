using Scripts.Common.Craft;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Workshop.Craft
{
    public class CraftMenuQualityUI : MonoBehaviour
    {
        [Inject] private ICraftController _craftController;

        public Image Icon;
        public Sprite[] QualityIcons;

        private ProductQuality _activeQuality 
        {
            get { return _craftController.ProductQuality; }
            set { _craftController.ProductQuality = value; }
        }

        private void Start() { }

        public void ChangeProductQuality()
        {
            var intQuality = (int)_activeQuality + 1;            

            if (Enum.IsDefined(typeof(ProductQuality), intQuality))
            {
                _activeQuality = (ProductQuality)intQuality;
            }
            else
            {
                _activeQuality = ProductQuality.Common;
            }
        }
    }
}
