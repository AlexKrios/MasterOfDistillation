using Scripts.Stores.Money;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Money
{
    public class MoneyUIController : IMoneyUIController
    {
        [Inject] private IUiController _uiController;
        [Inject] private IMoneyStore _moneyStore;

        private Text _moneyText;

        public void SetMoney(int value)
        {
            _moneyStore.Money = value;
            SetMoneyText();
        }

        public void PlusMoney(int value)
        {
            _moneyStore.Money += value;
            SetMoneyText();
        }

        private void SetMoneyText()
        {            
            if (!_moneyText)
            {
                _moneyText = _uiController.Find("Money").GetComponent<MoneyUI>().MoneyText;
            }

            _moneyText.text = _moneyStore.Money.ToString();
        }
    }
}
