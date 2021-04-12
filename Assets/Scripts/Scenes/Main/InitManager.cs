using Scripts.Objects;
using System;
using UnityEngine;
using Zenject;
using Scripts.Stores.Level;
using Scripts.Stores.Raw;
using Scripts.Stores.Product;
using Scripts.UI.Money;
using Scripts.UI.Level;
using Scripts.UI.Raw;
using Scripts.Stores.Money;
using Scripts.UI.Product;
using Scripts.Stores;
using Scripts.Timer;

namespace Scripts.Scenes.Main
{
    public class InitManager : MonoBehaviour
    {
        private Transform _sceneContext;

        [Inject] private MoneyUI.Factory _moneyUI;
        [Inject] private LevelUI.Factory _levelUI;
        [Inject] private RawUI.Factory _rawUI;
        [Inject] private ComponentUI.Factory _componentUI;
        [Inject] private ProductUI.Factory _productUI;        

        [Inject] private IRecipesStore _recipesStore;
        [Inject] private IMoneyStore _moneyStore;
        [Inject] private ILevelStore _levelStore;

        [Inject] private IRawStore _rawStore;

        [Inject] private IProductStore _rifleStore;        

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
            _componentUI.Create();
            _productUI.Create("Rifle");

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

            _rawStore.RawInfo = StartData.RawInfo;

            _recipesStore.Recipes = StartData.ProductsInfo;

            _sceneContext.GetComponent<ITimerController>().SetRawTimers();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _levelStore.Experience += 50;
            }
        }
    }

}