using Scripts.Objects;
using System;
using UnityEngine;
using Zenject;
using Scripts.Stores.Level;
using Scripts.Stores.Raw;
using Scripts.UI.Money;
using Scripts.UI.Level;
using Scripts.UI.Raw;
using Scripts.Stores.Money;
using Scripts.Timer;
using System.Collections.Generic;
using Scripts.Stores;

namespace Scripts.Scenes.Main
{
    public class InitManager : MonoBehaviour
    {
        private Transform _sceneContext;

        [Inject] private MoneyUI.Factory _moneyUI;
        [Inject] private LevelUI.Factory _levelUI;
        [Inject] private RawUI.Factory _rawUI;      

        [Inject] private IMoneyStore _moneyStore;
        [Inject] private ILevelStore _levelStore;

        [Inject] private IRawStore _rawStore;
        [Inject] private List<IStore> _storeList;

        public TextAsset jsonFile;
        [NonSerialized] public LoadObject StartData;

        [Inject]
        private void Construct([Inject(Id = "SceneContext")] Transform sceneContext)
        {
            _sceneContext = sceneContext;
        }

        private void Start()
        {
            _moneyUI.Create();
            _levelUI.Create();
            _rawUI.Create();

            StartData = InitStartData();

            SetStartData();
        }

        public LoadObject InitStartData()
        {
            return JsonUtility.FromJson<LoadObject>(jsonFile.text);
        }

        private void SetStartData()
        {
            _moneyStore.Money = StartData.MoneyInfo.Money;

            _levelStore.ExperienceMax = StartData.ExperienceMaxInfo;
            _levelStore.LevelInfo = StartData.LevelInfo;           

            _rawStore.InitRawListData(StartData.RawInfo);

            _storeList[0].LoadItemsCount(StartData.StoresInfo);

            _sceneContext.GetComponent<ITimerController>().SetRawTimers();
        }
    }

}