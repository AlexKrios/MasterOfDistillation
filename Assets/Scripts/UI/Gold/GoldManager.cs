using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Gold
{
    public class GoldManager : MonoBehaviour, ISetGoldInfo
    {
        public int gold;

        [SerializeField] private GameObject goldGameObject;

        private Text goldText;

        private void Start() 
        {
            goldText = goldGameObject.transform.Find("Count").GetComponent<Text>();
        }

        public void SetGold(int value)
        {
            gold = value;
            SetGoldText();
        }

        public void SetGoldText() 
        {
            if (goldText == null)
            {
                goldText = goldGameObject.transform.Find("Count").GetComponent<Text>();
            }

            goldText.text = gold.ToString(); 
        }
    }
}
