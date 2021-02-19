using Scripts.UI.Product;
using Zenject;

namespace Scripts.Stores
{
    public class AbstractProductStore : IProductStore
    {
        [Inject] protected IProductUIController _productUIStore;

        protected int _componentCommon;
        public int ComponentCommon
        {
            get { return _componentCommon; }
            set 
            { 
                _componentCommon = value;
                _productUIStore.OnSetComponentCommonText.Invoke();
            }
        }
        
        protected int _componentBronze;
        public int ComponentBronze
        {
            get { return _componentBronze; }
            set { _componentBronze = value; }
        }
        
        protected int _componentSilver;
        public int ComponentSilver
        {
            get { return _componentSilver; }
            set { _componentSilver = value; }
        }
        
        protected int _componentGold;
        public int ComponentGold
        {
            get { return _componentGold; }
            set { _componentGold = value; }
        }
    }
}
