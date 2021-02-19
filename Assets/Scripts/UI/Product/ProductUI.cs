using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Product
{
    public class ProductUI : MonoBehaviour
    {
        public Image ComponentCommonIcon;
        public Text ComponentCommonText;
        public Image ComponentBronzeIcon;
        public Text ComponentBronzeText;
        public Image ComponentSilverIcon;
        public Text ComponentSilverText;
        public Image ComponentGoldIcon;
        public Text ComponentGoldText;

        public class Factory : PlaceholderFactory<string, ProductUI> { }
    }
}
