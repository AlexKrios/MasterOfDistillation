using Assets.Scripts.Objects;
using Assets.Scripts.Stores.Level;
using Assets.Scripts.Stores.Money;
using Assets.Scripts.Stores.Product;
using Assets.Scripts.Stores.Raw;
using Assets.Scripts.Timer;
using Assets.Scripts.Ui.Level;
using Assets.Scripts.Ui.Money;
using Assets.Scripts.Ui.Order;
using Assets.Scripts.Ui.Raw;
using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Scenes
{
    [UsedImplicitly]
    public class MainInitManager : MonoBehaviour
    {
        private Transform _sceneContext;

        [Inject] private readonly MoneyUi.Factory _moneyUi;
        [Inject] private readonly LevelUi.Factory _levelUi;
        [Inject] private readonly RawUi.Factory _rawUi;

        [Inject] private readonly CraftGroup.Factory _craftOrder;

        [Inject] private readonly IMoneyStore _moneyStore;
        [Inject] private readonly ILevelStore _levelStore;

        [Inject] private readonly IRawStore _rawStore;
        [Inject] private readonly IProductStore _productStore;

        public TextAsset JsonFile;
        [NonSerialized] public LoadObject StartData;

        [Inject]
        private void Construct([Inject(Id = "SceneContext")] Transform sceneContext)
        {
            _sceneContext = sceneContext;
        }

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            _moneyUi.Create();
            _levelUi.Create();
            _rawUi.Create();

            _craftOrder.Create();

            StartData = InitStartData();

            SetStartData();
        }

        public LoadObject InitStartData()
        {
            return JsonUtility.FromJson<LoadObject>(JsonFile.text);
        }

        private void SetStartData()
        {
            _moneyStore.OnSetMoney.Invoke(StartData.MoneyInfo.Money);
            _levelStore.OnInitLevel.Invoke(StartData.LevelInfo);

            _rawStore.InitRawListData(StartData.RawInfo);

            _productStore.LoadItemsCount(StartData.StoresInfo);

            _sceneContext.GetComponent<ITimerController>().SetRawTimers();
        }

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _levelStore.OnSetExperience.Invoke(50);
            }
        }
    }
}