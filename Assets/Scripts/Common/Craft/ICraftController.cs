using UnityEngine;

namespace Scripts.Common.Craft
{
    public interface ICraftController
    {
        ProductData ActiveProduct { get; set; }
        ProductQuality ProductQuality { get; set; }

        void Add(string key, Coroutine coroutine);
        Coroutine FindByKey(string key);
        void Remove(string key);
    }
}
