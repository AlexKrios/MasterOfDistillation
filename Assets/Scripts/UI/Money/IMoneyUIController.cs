using UnityEngine.Events;

namespace Scripts.UI.Money
{
    public interface IMoneyUIController
    {
        UnityEvent OnSetMoneyText { get; set; }
    }
}
