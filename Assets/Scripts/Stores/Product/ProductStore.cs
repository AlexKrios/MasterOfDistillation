using Assets.Scripts.Objects.Item;
using Assets.Scripts.Objects.Item.Product;
using Assets.Scripts.Objects.Item.Product.Load;
using Assets.Scripts.Scriptable;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Objects.Item.Product.Types;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Stores.Product
{
    [UsedImplicitly]
    public class ProductStore : IProductStore
    {
        public Dictionary<string, ICraftable> Store { get; }

        public ProductStore()
        {
            if (Store == null)
            {
                Store = new Dictionary<string, ICraftable>();
            }

            var storeData = Resources.Load("Data/Products/ProductStoreData") as ProductStoreSettings;
            SetProductToStoreDictionary(storeData);
        }

        private void SetProductToStoreDictionary(ProductStoreSettings storeData)
        {
            foreach (var data in storeData.Data)
            {
                for (var i = 1; i <= 5; i++)
                {
                    var path = i != 5 ? $"{data.DirPath}/Component{i}" : $"{data.DirPath}/Product";

                    var product = ProductObjectFactory(path, data.SubType);
                    Store.Add(product.Name, product);
                }
            }
        }

        //TODO Сделать отдельный класс фабрику и поместить в DI
        private ProductObject ProductObjectFactory(string path, string subType)
        {
            var fileData = Resources.LoadAll<ItemScriptable>(path).First();

            var filesRecipes = Resources.LoadAll<RecipeScriptable>(path);
            var recipesList = new List<RecipeScriptable>(filesRecipes);

            return new ProductObject
            {
                Name = fileData.Name,
                ItemType = fileData.ItemType,
                ProductType = EnumParse.ParseStringToEnum<ProductType>(subType),
                Icon = fileData.Icon,

                Count = new List<int> { 0, 0, 0, 0 },

                Recipes = recipesList
            };
        }

        public void LoadItemsCount(List<ProductLoadObject> storesInfo)
        {
            foreach (var store in storesInfo)
            {
                foreach (var item in store.Items)
                {
                    Store[item.Name].Count = item.Count;
                }
            }
        }
    }
}
