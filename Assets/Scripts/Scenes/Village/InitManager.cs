using Scripts.Objects;
using Scripts.UI.Gold;
using Scripts.UI.Level;
using System;
using UnityEngine;

namespace Scripts.Scenes.Village
{
    public class InitManager : MonoBehaviour
    {
        private GameManager GameManager { get => GameManager.Instance; }
        private ILevelManager LevelManager { get => GameManager.levelManager; }
        private IGoldManager GoldManager { get => GameManager.goldManager; }

        public TextAsset jsonFile;
        [NonSerialized] public ResourcesObject startData;

        private void Start()
        {
            startData = InitStartData();

            SetStartData();
        }

        public ResourcesObject InitStartData()
        {
            return JsonUtility.FromJson<ResourcesObject>(jsonFile.text);
        }

        private void SetStartData()
        {
            LevelManager.LevelsExpirience = startData.levelExpInfo;
            LevelManager.Level = startData.levelInfo.level;            
            LevelManager.CurExpirience = startData.levelInfo.curExp;
            LevelManager.SetLevelExpirience();
            LevelManager.SetLevelPercent();

            GoldManager.Gold = startData.goldInfo.gold;
        }
    }

}