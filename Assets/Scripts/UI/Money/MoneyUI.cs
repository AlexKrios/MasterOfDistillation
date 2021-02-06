using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Money
{
    public class MoneyUI : MonoBehaviour
    {
        public Image MoneyIcon;
        public Text MoneyText;

        public class Factory : PlaceholderFactory<MoneyUI> { }
    }
}
