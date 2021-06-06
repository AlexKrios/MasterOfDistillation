using Assets.Scripts.Objects.Item.Craft;
using Assets.Scripts.Timer;
using Assets.Scripts.Ui.FullMenu.Common;
using Assets.Scripts.Ui.FullMenu.Craft.Controller;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

// ReSharper disable UnusedMember.Local
#pragma warning disable 649

namespace Assets.Scripts.Ui.FullMenu.Craft.Create
{
    [UsedImplicitly]
    public class CreateButton : MonoBehaviour
    {
        [Inject] private readonly CraftMenuFactory.Settings _craftMenuSettings;

        [Inject] private readonly IUiController _uiController;
        [Inject(Id = "SceneContext")] private Transform _sceneContext;

        private ICraftController _craftController;
        private IFullMenu _fullMenu;

        private void Awake()
        {
            _fullMenu = _uiController.Find(_craftMenuSettings.Name).GetComponent<IFullMenu>();
        }

        private void Start()
        {
            _craftController = _sceneContext.GetComponent<ICraftController>();
        }

        public void CraftItem()
        {            
            if (!_craftController.IsEnoughParts())
            {
                Debug.LogWarning("Нехватает ингридиентов");
                return;
            }
            
            if (!_craftController.IsHaveFreeCell())
            {
                Debug.LogWarning("Нехватает ячеек для крафта");
                return;
            }

            var craftObj = CraftObjectFactory();
            _craftController.StartCraft(craftObj);

            _fullMenu.Parts.SetPartsInfo();
        }

        public void StartRawTimer()
        {
            _sceneContext.GetComponent<ITimerController>().SetRawTimers();
        }

        //TODO Переделать в отдельынй класс и добавть в DI
        private CraftObject CraftObjectFactory()
        {
            return new CraftObject
            {
                Item = _fullMenu.ActiveItem.Product,
                Quality = _fullMenu.ActiveQuality,
            };
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<CreateButton> { }
    }
}
