using Scripts.Objects.Product;
using Scripts.Stores;
using UnityEngine;

namespace Scripts.Common.Craft
{
    public interface ICraftController
    {
        ProductObject ActiveProduct { get; set; }
        IProductStore ActiveStore { get; set; }

        void Add(string key, Coroutine coroutine);
        Coroutine FindByKey(string key);
        void Remove(string key);
    }
}
