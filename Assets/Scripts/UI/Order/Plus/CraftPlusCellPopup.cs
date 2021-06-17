using Assets.Scripts.Stores.Craft;
using Assets.Scripts.Stores.Level;
using Assets.Scripts.Stores.Money;
using Assets.Scripts.Ui.Popup;
using Assets.Scripts.Ui.Popup.TwoButton;
using JetBrains.Annotations;
using Zenject;

// ReSharper disable UnusedMember.Local

#pragma warning disable 649

namespace Assets.Scripts.Ui.Order.Plus
{
    [UsedImplicitly]
    public class CraftPlusCellPopup : PopupTwoButtonBase
    {
        [Inject] private readonly CraftGroupFactory.Settings _craftGroupSettings;

        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly IPopupController _popupController;

        [Inject] private readonly IMoneyStore _moneyStore;
        [Inject] private readonly ILevelStore _levelStore;
        [Inject] private readonly ICraftStore _craftStore;

        private CraftGroup _craftGroup;

        private void Start()
        {
            _craftGroup = _uiController.Find(_craftGroupSettings.Name).GetComponent<CraftGroup>();

            LeftButton.onClick.AddListener(AcceptButtonClick);
            RightButton.onClick.AddListener(CancelButtonClick);

            LeftButton.interactable = IsButtonInteractable();
        }

        private void AcceptButtonClick()
        {
            BuyNewCell();

            _popupController.Remove(gameObject);
        }

        private void CancelButtonClick()
        {
            _popupController.Remove(gameObject);
        }

        private bool IsButtonInteractable()
        {
            var data = _craftStore.GetCurrentData();
            var level = _levelStore.Level;
            var money = _moneyStore.Money;

            return money >= data.Cost && level >= data.UnlockLevel;
        }

        private void BuyNewCell()
        {
            var money = _moneyStore.Money - _craftStore.GetCurrentData().Cost;
            _moneyStore.OnSetMoney.Invoke(money);

            _craftGroup.CreateCell(_craftStore.CellCount);
            _craftStore.CellCount++;
        }
    }
}
