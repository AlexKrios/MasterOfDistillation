// ReSharper disable UnassignedField.Global

using JetBrains.Annotations;

namespace Assets.Scripts.Ui.Popup
{
    [UsedImplicitly]
    public class PopupConfig
    {
        public PopupObject InitPopupHaveNotParts()
        {
            return new PopupObject
            {
                Name = "HaveNotParts",
                Type = PopupType.Notification,
                Size = PopupSizeType.Small,
                Text = "Нехватает ингредиентов"
            };
        }

        public PopupObject InitPopupHaveNotCells()
        {
            return new PopupObject
            {
                Name = "HaveNotCells",
                Type = PopupType.Notification,
                Size = PopupSizeType.Small,
                Text = "Нехватает ячеек для крафта"
            };
        }

        public PopupObject InitPopupBuyNewCraftCell()
        {
            return new PopupObject
            {
                Name = "BuyNewCraftCell",
                Type = PopupType.TwoButton,
                Size = PopupSizeType.Small,
                Text = "Вы хотите купить новый слот?"
            };
        }
    }
}
