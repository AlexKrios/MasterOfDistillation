using Scripts.Objects.Product;
using Scripts.UI.Product;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Scripts.Stores
{
    public class AbstractProductStore : IProductStore
    {
        [Inject] protected IProductUIController _productUIStore;

        protected string productFilesPath;

        protected List<ProductStoreObject> _rifleStoreList = new List<ProductStoreObject>();
        public List<ProductStoreObject> RifleStoreList 
        {
            get { return _rifleStoreList; }
            set {_rifleStoreList = value; }
        }

        protected void SetProductToStoreList(List<ProductStoreObject> productList)
        {
            var files = Resources.LoadAll<ProductData>(productFilesPath);
            foreach (var file in files)
            {
                foreach (ProductQuality quality in Enum.GetValues(typeof(ProductQuality)))
                {
                    var product = ProductStoreFactory(file, quality);

                    productList.Add(product);
                }                
            }
        }

        private ProductStoreObject ProductStoreFactory(ProductData data, ProductQuality quality)
        {
            var storeProduct = new ProductStoreObject();

            storeProduct.ProductName = data.ProductName;
            storeProduct.Slug = data.Slug;

            storeProduct.Type = data.Type;
            storeProduct.SubType = data.SubType;

            storeProduct.Quality = quality;

            storeProduct.Count = 0;

            return storeProduct;            
        }
    }
}
