using UnityEngine.Events;

namespace Assets.Scripts.UI.Money
{
    public interface IMoneyUiController
    {
        UnityEvent OnSetMoneyText { get; set; }
    }
}
