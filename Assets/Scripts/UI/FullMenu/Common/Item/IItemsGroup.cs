using UnityEngine;

namespace Assets.Scripts.Ui.FullMenu.Common.Item
{
    public interface IItemsGroup
    {
        RectTransform Container { get; }

        void SetInitItem();
        void CreateItems();
        //void SetActiveItem();
    }
}
