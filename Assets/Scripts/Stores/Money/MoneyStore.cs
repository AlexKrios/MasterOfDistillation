using Scripts.UI.Money;
using Zenject;

namespace Scripts.Stores.Money
{
    public class MoneyStore : IMoneyStore
    {
        [Inject] private IMoneyUIController _moneyUIController;

        private int _money;
        public int Money
        {
            get { return _money; }
            set 
            { 
                _money = value;
                _moneyUIController.OnSetMoneyText.Invoke();
            }
        }
    }
}
