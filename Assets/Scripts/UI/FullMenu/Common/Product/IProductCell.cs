using UnityEngine;

namespace Assets.Scripts.Ui.FullMenu.Common.Product
{
    public interface IProductCell
    {
        Transform Transform { get; set; }

        void SetProductInfo();
    }
}
