using Scripts.Objects.Product.Load;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Stores
{
    public class AbstractStore : IStore
    {
        protected string itemSubType;
        public string ItemSubType { get => itemSubType; }

        protected string itemFilesPath;

        protected Dictionary<string, Dictionary<string, ProductData>> _allStore;
        public Dictionary<string, Dictionary<string, ProductData>> AllStore { get => _allStore; }

        protected Dictionary<string, ProductData> _data = new Dictionary<string, ProductData>();
        public Dictionary<string, ProductData> Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public AbstractStore()
        {
            if (_allStore == null)
            {
                _allStore = new Dictionary<string, Dictionary<string, ProductData>>();
            }

            if (_data == null)
            {
                _data = new Dictionary<string, ProductData>();
            }            
        }

        protected void SetProductToStoreDictionary(Dictionary<string, ProductData> dict)
        {
            var files = Resources.LoadAll<ProductData>(itemFilesPath);
            foreach (var file in files)
            {
                dict.Add(file.Data.Name, file);            
            }

            SubscribeDictionaryToAll(itemSubType, dict);
        }

        protected void SubscribeDictionaryToAll(string subType, Dictionary<string, ProductData> dict)
        {
            if (_allStore == null)
            {
                _allStore = new Dictionary<string, Dictionary<string, ProductData>>();
            }

            _allStore.Add(subType, dict);

            foreach(var a in _allStore.Keys)
            {
                Debug.Log(a);
            }
        }

        public void LoadItemsCount(List<ProductLoadObject> storesInfo)
        {
            var itemStore = _allStore[itemSubType];
            var loadStore = storesInfo.First(x => x.Name == itemSubType);

            foreach (var item in loadStore.Items)
            {
                itemStore[item.Name].Count = item.Count; 
            }
        }
    }
}
