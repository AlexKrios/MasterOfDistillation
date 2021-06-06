using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

// ReSharper disable ClassNeverInstantiated.Global
#pragma warning disable 649

namespace Assets.Scripts.Ui.FullMenu.Common.Quality
{
    public class QualityButton : MonoBehaviour, IQualityButton, IPointerClickHandler
    {
        [Inject] private readonly IUiController _uiController;

        private IFullMenu _fullMenu;

        [Header("Components")]
        [SerializeField] private Image _icon;

        [Header("Assets")]
        // ReSharper disable once CollectionNeverUpdated.Local
        [SerializeField] private List<Sprite> _qualityIcons;

        private ProductQuality ActiveQuality
        {
            get => _fullMenu.ActiveQuality;
            set => _fullMenu.ActiveQuality = value;
        }

        // ReSharper disable once UnusedMember.Local
        private void Awake()
        {
            _fullMenu = _uiController.FindByPart("Menu").GetComponent<IFullMenu>();
            _fullMenu.Quality = this;
        }

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            ActiveQuality = ProductQuality.Common;
        }

        public void OnPointerClick(PointerEventData eventData)
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

            SetQualityIcon(ActiveQuality);

            _fullMenu.Parts.SetPartsInfo();
        }

        public void ResetQuality()
        {
            ActiveQuality = ProductQuality.Common;
            SetQualityIcon(ProductQuality.Common);

            _fullMenu.Parts.SetPartsInfo();
        }

        private void SetQualityIcon(ProductQuality quality)
        {
            _icon.sprite = _qualityIcons[(int)quality];
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<QualityButton> { }
    }
}
