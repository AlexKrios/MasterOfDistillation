using Assets.Scripts.Ui;
using Assets.Scripts.Ui.Money;
using JetBrains.Annotations;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Stores.Money
{
    [UsedImplicitly]
    public class MoneyStore : IMoneyStore
    {
        [Inject] private readonly IUiController _uiController;

        public SetMoneyEvent OnSetMoney { get; }

        private Text _moneyText;

        public int Money { get; private set; }

        public MoneyStore()
        {
            OnSetMoney = new SetMoneyEvent();

            OnSetMoney.AddListener(SetMoney);
        }

        private void SetMoney(int money)
        {
            Money = money;

            if (!_moneyText)
                _moneyText = _uiController.Find("Money").GetComponent<MoneyUi>().MoneyText;

            _moneyText.text = Money.ToString();
        }
    }

    public class SetMoneyEvent : UnityEvent<int> { }
}
