using Scripts.Common.Craft;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Workshop.Craft
{
    public class CraftMenuUIController : ICraftMenuUIController
    {
        [Inject] private IUiController _uiController;
        [Inject] private ICraftController _craftController;

        private ProductQuality _productQuality { get => _craftController.ProductQuality; }
        
        private Image _qualityIcon;
        private Sprite[] _qualityIcons;

        public UnityEvent OnSetQualityIcon { get; set; } = new UnityEvent();

        public CraftMenuUIController()
        {
            OnSetQualityIcon.AddListener(SetQualityIcon);
        }

        private void SetQualityIcon()
        {
            if (!_qualityIcon)
            {
                var qualityBtn = _uiController.FindByPart("CraftMenu").GetComponent<CraftMenuUI>().QualityBtn;
                var script = qualityBtn.GetComponent<CraftMenuQualityUI>();

                _qualityIcon = script.Icon;
                _qualityIcons = script.QualityIcons;                
            }

            _qualityIcon.sprite = _qualityIcons[(int)_productQuality];
        }
    }
}
