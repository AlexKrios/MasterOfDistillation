using Scripts.Stores;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Product
{
    public abstract class AbstractProductUIController : IProductUIController
    {
        [Inject] protected IUiController _uiController;
        [Inject] protected IProductStore _productStore;

        public UnityEvent OnSetComponentCommonText { get; set; } = new UnityEvent();
        public UnityEvent OnSetComponentBronzeText { get; set; } = new UnityEvent();
        public UnityEvent OnSetComponentSilverText { get; set; } = new UnityEvent();
        public UnityEvent OnSetComponentGoldText { get; set; } = new UnityEvent();

        protected Text _componentCommonText;
        protected Text _componentBronzeText;
        protected Text _componentSilverText;
        protected Text _componentGoldText;

        public AbstractProductUIController()
        {
            OnSetComponentCommonText.AddListener(SetComponentCommonText);
            OnSetComponentBronzeText.AddListener(SetComponentBronzeText);
            OnSetComponentSilverText.AddListener(SetComponentSilverText);
            OnSetComponentGoldText.AddListener(SetComponentGoldText);
        }

        protected virtual void SetComponentCommonText() { }

        private void SetComponentBronzeText()
        {

        }

        private void SetComponentSilverText()
        {

        }

        private void SetComponentGoldText()
        {

        }
    }
}
