using Scripts.Objects.Raw;
using Scripts.UI.Raw;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Scripts.Stores.Raw
{
    public class RawStore : IRawStore
    {
        [Inject] private IRawUIController _rawUIController;

        private List<RawObject> _rawInfo;
        public List<RawObject> RawInfo 
        {
            get { return _rawInfo; } 
            set
            {
                _rawInfo = value;
                Iron = value.First(x => x.Name == "Iron").Count;
            }
        }

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
