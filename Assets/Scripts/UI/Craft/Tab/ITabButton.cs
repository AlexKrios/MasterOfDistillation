using System.Collections.Generic;
using Assets.Scripts.Objects.Item.Product.Types;

namespace Assets.Scripts.Ui.Craft.Tab
{
    public interface ITabButton
    {
        List<ProductType> Keys { get; }

        void SetInactiveTabImage();
        void SetActiveTabImage();
    }
}
