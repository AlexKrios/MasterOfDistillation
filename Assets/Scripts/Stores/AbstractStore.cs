using Scripts.Objects.Product;
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

        protected Dictionary<string, Dictionary<string, ProductFullData>> _allStore;
        public Dictionary<string, Dictionary<string, ProductFullData>> AllStore { get => _allStore; }

        protected Dictionary<string, ProductFullData> _data = new Dictionary<string, ProductFullData>();
        public Dictionary<string, ProductFullData> Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public AbstractStore()
        {
            if (_allStore == null)
            {
                _allStore = new Dictionary<string, Dictionary<string, ProductFullData>>();
            }

            if (_data == null)
            {
                _data = new Dictionary<string, ProductFullData>();
            }            
        }

        protected void SetProductToStoreDictionary(Dictionary<string, ProductFullData> dict)
        {
            var files = Resources.LoadAll<ProductFullData>(itemFilesPath);
            foreach (var file in files)
            {
                dict.Add(file.Data.Name, file);            
            }

            SubscribeDictionaryToAll(itemSubType, dict);
        }

        protected void SubscribeDictionaryToAll(string subType, Dictionary<string, ProductFullData> dict)
        {
            if (_allStore == null)
            {
                _allStore = new Dictionary<string, Dictionary<string, ProductFullData>>();
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
