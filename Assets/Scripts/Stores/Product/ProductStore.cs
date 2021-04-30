using Scripts.Objects.Product.Load;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Stores.Product
{
    public class ProductStore : IStore
    {
        private Dictionary<string, Dictionary<string, ProductData>> _allStore;
        public Dictionary<string, Dictionary<string, ProductData>> AllStore { get => _allStore; }

        public ProductStore()
        {
            if (_allStore == null)
            {
                _allStore = new Dictionary<string, Dictionary<string, ProductData>>();
            }

            var storeData = Resources.Load("Data/Products/ProductStoreData") as ProductStoreSettings;
            SetProductToStoreDictionary(storeData);
        }

        private void SetProductToStoreDictionary(ProductStoreSettings storeData)
        {
            foreach (var data in storeData.Data)
            {
                var dict = new Dictionary<string, ProductData>();

                var files = Resources.LoadAll<ProductData>(data.DirPath);
                foreach (var file in files)
                {
                    file.Reset();
                    dict.Add(file.Data.Name, file);
                }

                SubscribeDictionaryToAll(data.SubType, dict);
            }
        }

        private void SubscribeDictionaryToAll(string subType, Dictionary<string, ProductData> dict)
        {
            if (_allStore == null)
            {
                _allStore = new Dictionary<string, Dictionary<string, ProductData>>();
            }

            _allStore.Add(subType, dict);
        }

        public void LoadItemsCount(List<ProductLoadObject> storesInfo)
        {
            foreach (var store in storesInfo)
            {
                var loadStore = _allStore[store.Name];
                foreach (var item in store.Items)
                {
                    loadStore[item.Name].Count = item.Count;
                }
            }
        }
    }
}
