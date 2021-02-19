using UnityEngine.Events;

namespace Scripts.UI.Product
{
    public interface IProductUIController
    {
        UnityEvent OnSetComponentCommonText { get; set; }
        UnityEvent OnSetComponentBronzeText { get; set; }
        UnityEvent OnSetComponentSilverText { get; set; }
        UnityEvent OnSetComponentGoldText { get; set; }
    }
}
