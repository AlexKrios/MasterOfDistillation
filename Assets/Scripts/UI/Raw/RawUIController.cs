﻿using System;
using Assets.Scripts.Stores.Raw;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.Raw
{
    [Serializable]
    public class RawTextEvent : UnityEvent<string> { }

    public class RawUiController : IRawUiController
    {
        [Inject] private IUiController _uiController;
        [Inject] private IRawStore _rawStore;

        public RawTextEvent RawTextEvent { get; set; }

        private Text _ironText;

        public RawUiController()
        {
            if (RawTextEvent == null)
            {
                RawTextEvent = new RawTextEvent();
            }

            RawTextEvent.AddListener(SetRawText);
        }

        private void SetRawText(string raw)
        {
            switch (raw)
            {
                case "Iron":
                    SetIronText();
                    break;
            }
        }

        #region Iron
        private void SetIronText()
        {
            if (!_ironText)
            {
                _ironText = _uiController.Find("Raw").GetComponent<RawUi>().IronText;
            }

            _ironText.text = _rawStore.RawData["Iron"].Count.ToString();
        }
        #endregion
    }
}
