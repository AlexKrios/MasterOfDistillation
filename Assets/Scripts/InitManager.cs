using Scripts.Objects;
using Scripts.UI.Gold;
using Scripts.UI.Level;
using UnityEngine;

namespace Scripts
{
    public class InitManager : MonoBehaviour
    {
        private GameManager GameManager { get => GameManager.Instance; }
        private LevelManager LevelManager { get => GameManager.levelManager; }
        private GoldManager GoldManager { get => GameManager.goldManager; }

        public TextAsset jsonFile;
        public ResourcesObject startData;

        private void Start()
        {
            startData = LoadStartData();

            SetStartData();
        }

        public ResourcesObject LoadStartData()
        {
            return JsonUtility.FromJson<ResourcesObject>(jsonFile.text);
        }

        private void SetStartData()
        {
            LevelManager.SetLevelExp(startData.levelExpInfo);
            LevelManager.SetLevel(startData.levelInfo.level);
            LevelManager.SetLevelPercent();
            LevelManager.SetCurExp(startData.levelInfo.curExp, false);
            LevelManager.SetExp();           

            GoldManager.SetGold(startData.goldInfo.gold);
        }
    }

}