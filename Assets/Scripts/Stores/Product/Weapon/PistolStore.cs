namespace Scripts.Stores.Product.Weapon
{
    public class PistolStore : AbstractStore 
    {
        public PistolStore()
        {
            itemSubType = "Pistol";
            itemFilesPath = "Data/Products/Weapon/Pistol";

            SetProductToStoreDictionary(_data);
        }
    }
}
