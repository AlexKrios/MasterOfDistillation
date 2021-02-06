using Scripts.Objects;
using System;
using UnityEngine;
using Zenject;
using Scripts.UI.Money;
using Scripts.UI.Level;
using Scripts.Stores.Level;

namespace Scripts.Scenes.Main
{
    public class InitManager : MonoBehaviour
    {
        [Inject] private MoneyUI.Factory _moneyUI;
        [Inject] private LevelUI.Factory _levelUI;

        [Inject] private IMoneyUIController _moneyUIController;
        [Inject] private ILevelStore _levelStore;
        [Inject] private ILevelUIController _levelUIController;

        public TextAsset jsonFile;
        [NonSerialized] public ResourcesObject startData;

        private void Start()
        {
            _moneyUI.Create();
            _levelUI.Create();

            startData = InitStartData();

            SetStartData();            
        }

        public ResourcesObject InitStartData()
        {
            return JsonUtility.FromJson<ResourcesObject>(jsonFile.text);
        }

        private void SetStartData()
        {
            _levelStore.LevelsExpirience = startData.levelExpInfo;
            _levelUIController.SetLevel(startData.levelInfo.level);
            _levelUIController.SetCurrentExperience(startData.levelInfo.curExp);
            _levelUIController.SetLevelExperience();
            _levelUIController.SetLevelPercent();

            _moneyUIController.SetMoney(startData.moneyInfo.money);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _levelUIController.PlusCurrentExperience(50);
            }
        }
    }

}