using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.Money
{
    public class MoneyUi : MonoBehaviour
    {
        public Image MoneyIcon;
        public Text MoneyText;

        public class Factory : PlaceholderFactory<MoneyUi> { }
    }
}
