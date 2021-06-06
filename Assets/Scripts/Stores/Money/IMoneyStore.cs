namespace Assets.Scripts.Stores.Money
{
    public interface IMoneyStore
    {
        SetMoneyEvent OnSetMoney { get; }
    }
}
