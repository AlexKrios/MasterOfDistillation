namespace Scripts.Stores.Product.Weapon.Rifle
{
    public class RifleStore : AbstractProductStore 
    {
        public RifleStore()
        {
            productFilesPath = "Products/Weapon/Rifle/Scriptable";

            SetProductToStoreList(RifleStoreList);
        }
    }
}
