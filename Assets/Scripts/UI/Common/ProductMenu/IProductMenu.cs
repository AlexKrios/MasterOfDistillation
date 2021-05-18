using Assets.Scripts.Stores.Product;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Common.ProductMenu
{
    public interface IProductMenu
    {
        IProductStore ProductStore { get; }

        Text Title { get; }
        ITabsGroup Tabs { get; set; }
        IItemsGroup Items { get; set; }
    }
}
