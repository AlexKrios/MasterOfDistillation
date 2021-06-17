namespace Assets.Scripts.Stores.Money
{
    public interface IMoneyStore
    {
        int Money { get; }

        SetMoneyEvent OnSetMoney { get; }
    }
}
