using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Workshop.Craft.Quality
{
    public class QualityButton : MonoBehaviour
    {
        [SerializeField] private CraftMenuUI _menu;

        [Header("Components")]
        [SerializeField] private Image _icon;

        [Header("Assets")]
        [SerializeField] private List<Sprite> _qualityIcons;

        private ProductQuality _activeQuality = ProductQuality.Common;
        public ProductQuality ActiveQuality
        {
            get { return _activeQuality; }
            set
            {
                _activeQuality = value;
                SetQualityIcon(value);
                _menu.PartGroup.SetPartsInfo();
            }
        }

        private void Start() { }

        public void ChangeQuality()
        {
            var intQuality = (int)ActiveQuality + 1;            

            if (Enum.IsDefined(typeof(ProductQuality), intQuality))
            {
                ActiveQuality = (ProductQuality)intQuality;
            }
            else
            {
                ActiveQuality = ProductQuality.Common;
            }
        }

        public void ResetQuality()
        {
            ActiveQuality = ProductQuality.Common;
        }

        private void SetQualityIcon(ProductQuality quality)
        {
            _icon.sprite = _qualityIcons[(int)quality];
        }
    }
}
