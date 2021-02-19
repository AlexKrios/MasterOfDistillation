using Scripts.Stores.Raw;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Raw
{
    public class RawUIController : IRawUIController
    {
        [Inject] private IUiController _uiController;
        [Inject] private IRawStore _rawStore;

        private Text _ironText;

        public UnityEvent OnSetIronText { get; set; } = new UnityEvent();

        public RawUIController()
        {
            OnSetIronText.AddListener(SetIronText);
        }

        #region Iron
        private void SetIronText()
        {
            if (!_ironText)
            {
                _ironText = _uiController.Find("Raw").GetComponent<RawUI>().IronText;
            }

            _ironText.text = _rawStore.Iron.ToString();
        }
        #endregion
    }
}
