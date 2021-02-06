namespace Scripts.Stores.Money
{
    public class MoneyStore : IMoneyStore
    {
        private int _money;
        public int Money
        {
            get { return _money; }
            set { _money = value; }
        }
    }
}
