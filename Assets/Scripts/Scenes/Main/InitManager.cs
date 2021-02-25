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
using Scripts.Stores.Product.Weapon.Rifle;
using Scripts.Stores;

namespace Scripts.Scenes.Main
{
    public class InitManager : MonoBehaviour
    {
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
        [NonSerialized] public ResourcesObject StartData;

        private void Construct(RifleStore rifleStore)
        {
            _rifleStore = rifleStore;
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

        public ResourcesObject InitStartData()
        {
            return JsonUtility.FromJson<ResourcesObject>(jsonFile.text);
        }

        private void SetStartData()
        {
            _moneyStore.Money = StartData.MoneyInfo.Money;

            _levelStore.LevelsExperience = StartData.LevelExperienceInfo;
            _levelStore.Level = StartData.LevelInfo.Level;
            _levelStore.CurrentExperience = StartData.LevelInfo.CurrentExperience;            

            _rawStore.Iron = StartData.RawInfo.Iron;

            _rifleStore.Components = StartData.RifleStoreInfo.Components;

            _recipesStore.Recipes = StartData.ProductsInfo;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _levelStore.CurrentExperience += 50;
            }
        }
    }

}