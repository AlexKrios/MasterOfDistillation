using UnityEngine.UI;

namespace Scripts.UI.Gold
{
    public class GoldController : IGoldController
    {
        private int _gold;
        public int Gold
        {
            get { return _gold; }
            set 
            {
                _gold = value;
                UpdateGoldText();
            }
        }

        private Text _goldText;

        public GoldController(Text goldText)
        {
            _goldText = goldText;
        }

        private void UpdateGoldText()
        {
            if (!_goldText)
            {
                return;
            }

            _goldText.text = _gold.ToString();
        }
    }
}
