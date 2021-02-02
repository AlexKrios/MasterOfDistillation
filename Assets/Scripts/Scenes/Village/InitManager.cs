using Scripts.Objects;
using Scripts.UI.Gold;
using Scripts.UI.Level;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.Scenes.Village
{
    public class InitManager : MonoBehaviour
    {
        private IGoldController _goldController;
        private ILevelController _levelController;

        public TextAsset jsonFile;
        [NonSerialized] public ResourcesObject startData;

        [Inject]
        public void Construct(IGoldController goldController, ILevelController levelController)
        {
            _goldController = goldController;
            _levelController = levelController;
        }

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
            _levelController.LevelsExpirience = startData.levelExpInfo;
            _levelController.Level = startData.levelInfo.level;
            _levelController.CurExpirience = startData.levelInfo.curExp;
            _levelController.SetLevelExpirience();
            _levelController.SetLevelPercent();

            _goldController.Gold = startData.goldInfo.gold;
            //_goldManager.Gold = startData.goldInfo.gold;
        }
    }

}