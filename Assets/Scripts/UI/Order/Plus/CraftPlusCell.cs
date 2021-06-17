using Assets.Scripts.Ui.Popup;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

// ReSharper disable UnusedMember.Local

#pragma warning disable 649

namespace Assets.Scripts.Ui.Order.Plus
{
    [UsedImplicitly]
    public class CraftPlusCell : MonoBehaviour, IPointerClickHandler
    {
        [Inject] private readonly IPopupFactory _popupFactory;
        [Inject] private readonly PopupConfig _popupConfig;

        public void OnPointerClick(PointerEventData eventData)
        {
            var config = _popupConfig.InitPopupBuyNewCraftCell();
            _popupFactory.CreatePopup<CraftPlusCellPopup>(config);
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<CraftPlusCell> { }
    }
}
