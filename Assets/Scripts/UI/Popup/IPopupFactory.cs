namespace Assets.Scripts.Ui.Popup
{
    public interface IPopupFactory
    {
        void CreatePopup<T>(PopupObject config) where T : PopupBase;
    }
}
