using Assets.Scripts.Stores.Money;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.Money
{
    public class MoneyUiController : IMoneyUiController
    {
        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly IMoneyStore _moneyStore;

        private Text _moneyText;

        public UnityEvent OnSetMoneyText { get; set; }

        public MoneyUiController()
        {
            OnSetMoneyText = new UnityEvent();

            OnSetMoneyText.AddListener(SetMoneyText);
        }

        private void SetMoneyText()
        {            
            if (!_moneyText)
            {
                _moneyText = _uiController.Find("Money").GetComponent<MoneyUi>().MoneyText;
            }

            _moneyText.text = _moneyStore.Money.ToString();
        }
    }
}
