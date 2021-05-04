using Scripts.Objects.Product;
using Scripts.Objects.Product.Load;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Stores.Product
{
    public class ProductStore : IStore
    {
        public Dictionary<string, Dictionary<string, ProductFullData>> AllStore { get; private set; }

        public ProductStore()
        {
            if (AllStore == null)
            {
                AllStore = new Dictionary<string, Dictionary<string, ProductFullData>>();
            }

            var storeData = Resources.Load("Data/Products/ProductStoreData") as ProductStoreSettings;
            SetProductToStoreDictionary(storeData);
        }

        private void SetProductToStoreDictionary(ProductStoreSettings storeData)
        {
            foreach (var data in storeData.Data)
            {
                var dict = new Dictionary<string, ProductFullData>();

                var files = Resources.LoadAll<ProductFullData>(data.DirPath);
                foreach (var file in files)
                {
                    file.Reset();
                    dict.Add(file.Data.Name, file);
                }

                SubscribeDictionaryToAll(data.SubType, dict);
            }
        }

        private void SubscribeDictionaryToAll(string subType, Dictionary<string, ProductFullData> dict)
        {
            if (AllStore == null)
            {
                AllStore = new Dictionary<string, Dictionary<string, ProductFullData>>();
            }

            AllStore.Add(subType, dict);
        }

        public void LoadItemsCount(List<ProductLoadObject> storesInfo)
        {
            foreach (var store in storesInfo)
            {
                var loadStore = AllStore[store.Name];
                foreach (var item in store.Items)
                {
                    loadStore[item.Name].Count = item.Count;
                }
            }
        }
    }
}
