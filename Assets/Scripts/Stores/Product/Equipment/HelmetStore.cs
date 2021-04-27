namespace Scripts.Stores.Product.Equipment
{
    public class HelmetStore : AbstractStore 
    {
        public HelmetStore()
        {
            itemSubType = "Helmet";
            itemFilesPath = "Data/Products/Equipment/Helmet";

            SetProductToStoreDictionary(_data);
        }
    }
}
