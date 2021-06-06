using Assets.Scripts.Objects.Item;

namespace Assets.Scripts.Ui.FullMenu.Common.Item
{
    public interface IItemButton
    {
        ICraftable Product { get; }

        void SetItemInactive();
        void SetItemActive();
    }
}
