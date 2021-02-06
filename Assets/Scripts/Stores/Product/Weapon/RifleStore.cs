using Scripts.Stores.Raw;

namespace Scripts.Stores.Product.Weapon.Rifle
{
    public class RifleStore : AbstractProductStore 
    {
        public RifleStore(IRawStore rawStore)
        {
            _rawStore = rawStore;
        }
    }
}
