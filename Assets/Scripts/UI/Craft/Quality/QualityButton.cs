using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 649

namespace Assets.Scripts.UI.Craft.Quality
{
    public class QualityButton : MonoBehaviour
    {
        [SerializeField] private CraftMenu _menu;

        [Header("Components")]
        [SerializeField] private Image _icon;

        [Header("Assets")]
        // ReSharper disable once CollectionNeverUpdated.Local
        [SerializeField] private List<Sprite> _qualityIcons;

        private ProductQuality _activeQuality = ProductQuality.Common;
        public ProductQuality ActiveQuality
        {
            get => _activeQuality;
            set
            {
                _activeQuality = value;
                SetQualityIcon(value);
                _menu.PartGroup.SetPartsInfo();
            }
        }

        // ReSharper disable once UnusedMember.Local
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
