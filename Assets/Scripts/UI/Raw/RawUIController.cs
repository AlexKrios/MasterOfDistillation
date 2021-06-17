using Assets.Scripts.Stores.Raw;
using JetBrains.Annotations;
using System;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Ui.Raw
{
    [UsedImplicitly]
    public class RawUiController : IRawUiController
    {
        [Inject] private IUiController _uiController;
        [Inject] private IRawStore _rawStore;

        public RawTextEvent RawTextEvent { get; set; }

        private Text _weaponText;

        public RawUiController()
        {
            RawTextEvent = new RawTextEvent();

            RawTextEvent.AddListener(SetRawText);
        }

        private void SetRawText(string raw)
        {
            switch (raw)
            {
                case "Weapon":
                    SetWeaponText();
                    break;
            }
        }

        #region Weapon
        private void SetWeaponText()
        {
            if (!_weaponText)
                _weaponText = _uiController.Find("Raw").GetComponent<RawUi>().WeaponText;

            _weaponText.text = _rawStore.RawData["Weapon"].Count.ToString();
        }
        #endregion
    }

    [Serializable]
    public class RawTextEvent : UnityEvent<string> { }
}
