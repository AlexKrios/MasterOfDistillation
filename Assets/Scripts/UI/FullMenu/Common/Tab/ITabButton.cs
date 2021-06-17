using Assets.Scripts.Stores;
using Assets.Scripts.Stores.Product.Types;
using System.Collections.Generic;

namespace Assets.Scripts.Ui.FullMenu.Common.Tab
{
    public interface ITabButton
    {
        ItemType Title { get; }
        List<ProductType> Keys { get; }

        void SetInactiveTabImage();
        void SetActiveTabImage();
    }
}
