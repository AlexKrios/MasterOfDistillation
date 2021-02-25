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

        public UnityEvent OnSetComponentText { get; set; } = new UnityEvent();

        protected Text _componentText;

        public AbstractProductUIController()
        {
            OnSetComponentText.AddListener(SetComponentText);
        }

        protected virtual void SetComponentText() { }
    }
}
