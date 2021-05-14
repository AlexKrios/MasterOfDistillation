using Assets.Scripts.UI.Money;
using Zenject;

namespace Assets.Scripts.Stores.Money
{
    public class MoneyStore : IMoneyStore
    {
        [Inject] private readonly IMoneyUiController _moneyUiController;

        private int _money;
        public int Money
        {
            get => _money;
            set 
            { 
                _money = value;
                _moneyUiController.OnSetMoneyText.Invoke();
            }
        }
    }
}
