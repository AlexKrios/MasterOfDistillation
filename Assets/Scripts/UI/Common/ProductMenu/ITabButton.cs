using Assets.Scripts.Objects.Item;
using Assets.Scripts.Objects.Item.Product.Types;
using System.Collections.Generic;

namespace Assets.Scripts.Ui.Common.ProductMenu
{
    public interface ITabButton
    {
        ItemType Title { get; }
        List<ProductType> Keys { get; }

        void SetInactiveTabImage();
        void SetActiveTabImage();
    }
}
