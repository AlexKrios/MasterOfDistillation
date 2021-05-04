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
using Scripts.Stores;

namespace Scripts.Scenes.Main
{
    public class InitManager : MonoBehaviour
    {
        private Transform _sceneContext;

        [Inject] private readonly MoneyUI.Factory _moneyUI;
        [Inject] private readonly LevelUI.Factory _levelUI;
        [Inject] private readonly RawUI.Factory _rawUI;      

        [Inject] private readonly IMoneyStore _moneyStore;
        [Inject] private readonly ILevelStore _levelStore;

        [Inject] private readonly IRawStore _rawStore;
        [Inject] private readonly IStore _store;

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
            _levelStore.LevelInfo = StartData.LevelInfo;

            _rawStore.InitRawListData(StartData.RawInfo);

            _store.LoadItemsCount(StartData.StoresInfo);

            _sceneContext.GetComponent<ITimerController>().SetRawTimers();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _levelStore.Experience += 50;
            }
        }
    }
}