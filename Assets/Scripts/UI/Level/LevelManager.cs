using Scripts.Objects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Level
{
    public class LevelManager : MonoBehaviour
    {
        private List<LevelExpObject> levelExp;
        public int level;
        public float exp;
        public float curExp;        

        [SerializeField] private GameObject levelGameObject;

        private Text levelText;
        private Text levelPercentText;
        private Text expText;
        private Text curExpText;

        private void Start()
        {
            levelText = levelGameObject.transform.Find("Icon/Count").GetComponent<Text>();
            levelPercentText = levelGameObject.transform.Find("Percent").GetComponent<Text>();
        }

        /* List of level expirience */
        public void SetLevelExp(List<LevelExpObject> value) => levelExp = value;

        /* Level action */
        public void SetLevel(int value)
        {
            level = value;
            SetLevelText();
        }
        private void SetOneLevel() 
        {
            level++;
            SetLevelText();
        }
        private void SetLevelUp()
        {
            ResetCurExp();
            SetOneLevel();
            SetExp();
        }
        private void SetLevelText() 
        {
            if (levelText == null) 
            {
                levelGameObject.transform.Find("Icon/Count").GetComponent<Text>();                
            }

            levelText.text = level.ToString();
        }
        
        /* Level progeress action */
        public void SetLevelPercent()
        {
            if (levelPercentText == null)
            {
                levelGameObject.transform.Find("Percent").GetComponent<Text>();
            }

            var levelPercent = curExp / (exp / 100);
            levelPercentText.text = string.Format("{0:f0}%", levelPercent);
        }

        /* Current level expirience action */
        public void SetCurExp(int value, bool plus = true)
        {
            if (plus)
            {
                curExp += value;
            }
            else
            {
                curExp = value;
            }            

            if (curExp >= exp)
            {
                SetLevelUp();
            }

            SetLevelPercent();
        }
        private void ResetCurExp() => curExp -= exp;
        public void SetCurExpText() => curExpText.text = curExp.ToString();

        /* Current level max expirirence action */
        public void SetExp() => exp = levelExp[level - 1].max;
        public void SetExpText() => expText.text = exp.ToString();                       

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SetCurExp(20);
            }
        }
    }
}