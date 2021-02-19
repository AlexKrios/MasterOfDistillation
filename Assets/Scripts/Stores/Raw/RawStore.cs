using Scripts.UI.Raw;
using Zenject;

namespace Scripts.Stores.Raw
{
    public class RawStore : IRawStore
    {
        [Inject] private IRawUIController _rawUIController;

        private int _iron;
        public int Iron
        {
            get { return _iron; }
            set 
            { 
                _iron = value;
                _rawUIController.OnSetIronText.Invoke();
            }
        }
    }
}
