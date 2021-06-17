using Assets.Scripts.Controllers.Craft;
using Assets.Scripts.Controllers.Timer;
using Assets.Scripts.Stores.Craft;
using Assets.Scripts.Ui.FullMenu.Common;
using Assets.Scripts.Ui.Popup;
using Assets.Scripts.Ui.Popup.Notification;
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
        [Inject] private readonly IPopupFactory _popupFactory;
        [Inject] private readonly PopupConfig _popupConfig;

        [Inject(Id = "SceneContext")] private ICraftController _craftController;
        [Inject(Id = "SceneContext")] private ITimerController _timerController;

        private IFullMenu _fullMenu;

        private void Awake()
        {
            _fullMenu = _uiController.Find(_craftMenuSettings.Name).GetComponent<IFullMenu>();
        }

        public void CraftItem()
        {            
            if (!_craftController.IsEnoughParts())
            {
                var config = _popupConfig.InitPopupHaveNotParts();
                _popupFactory.CreatePopup<PopupNotificationBase>(config);

                Debug.LogWarning(config.Text);
                return;
            }
            
            if (!_craftController.IsHaveFreeCell())
            {
                var config = _popupConfig.InitPopupHaveNotCells();
                _popupFactory.CreatePopup<PopupNotificationBase>(config);

                Debug.LogWarning(config.Text);
                return;
            }

            var craftObj = CraftObjectFactory();
            _craftController.StartCraft(craftObj);

            _fullMenu.Parts.SetPartsInfo();
        }

        public void StartRawTimer()
        {
            _timerController.SetRawTimers();
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
