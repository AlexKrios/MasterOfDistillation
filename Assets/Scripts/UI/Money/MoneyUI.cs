using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Ui.Money
{
    [UsedImplicitly]
    public class MoneyUi : MonoBehaviour
    {
        public Image MoneyIcon;
        public Text MoneyText;

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<MoneyUi> { }
    }
}
