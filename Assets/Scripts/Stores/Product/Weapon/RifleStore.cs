namespace Scripts.Stores.Product.Weapon
{
    public class RifleStore : AbstractStore 
    {
        public RifleStore()
        {
            itemSubType = "Rifle";
            itemFilesPath = "Data/Products/Weapon/Rifle";

            SetProductToStoreDictionary(_data);
        }
    }
}
