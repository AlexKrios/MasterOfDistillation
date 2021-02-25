using Scripts.Objects.Component;
using Scripts.UI.Product;
using System.Collections.Generic;
using Zenject;

namespace Scripts.Stores
{
    public class AbstractProductStore : IProductStore
    {
        [Inject] protected IProductUIController _productUIStore;

        protected List<ComponentObject> _components;
        public List<ComponentObject> Components
        {
            get { return _components; }
            set
            {
                _components = value;
                _productUIStore.OnSetComponentText.Invoke();
            }
        }
    }
}
