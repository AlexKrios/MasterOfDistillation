using UnityEngine.Events;

namespace Scripts.UI.Product
{
    public interface IProductUIController
    {
        UnityEvent OnSetComponentText { get; set; }
    }
}
