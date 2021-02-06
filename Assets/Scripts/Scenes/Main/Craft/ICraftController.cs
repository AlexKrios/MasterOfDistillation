using UnityEngine;

namespace Scripts.Scenes.Main.Craft
{
    public interface ICraftController
    {
        void Add(string key, Coroutine coroutine);
        Coroutine FindByKey(string key);
        void Remove(string key);
    }
}
