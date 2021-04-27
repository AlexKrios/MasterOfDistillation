using Scripts.Stores.Raw;
using System;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Raw
{
    [Serializable]
    public class RawTextEvent : UnityEvent<string> { }

    public class RawUIController : IRawUIController
    {
        [Inject] private IUiController _uiController;
        [Inject] private IRawStore _rawStore;

        public RawTextEvent RawTextEvent { get; set; }

        private Text _ironText;

        public RawUIController()
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
                _ironText = _uiController.Find("Raw").GetComponent<RawUI>().IronText;
            }

            _ironText.text = _rawStore.RawData["Iron"].Count.ToString();
        }
        #endregion
    }
}
