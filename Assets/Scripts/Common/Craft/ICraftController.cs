using UnityEngine;

namespace Scripts.Common.Craft
{
    public interface ICraftController
    {
        string ActiveCraft { get; set; }
        string ActiveQuality { get; set; }

        void Add(string key, Coroutine coroutine);
        Coroutine FindByKey(string key);
        void Remove(string key);
        void ResetActive();
    }
}
