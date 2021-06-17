using Assets.Scripts.Ui.Order.Data;

namespace Assets.Scripts.Stores.Craft
{
    public interface ICraftStore
    {
        int CellCount { get; set; }

        OrderDataObject GetCurrentData();
    }
}
