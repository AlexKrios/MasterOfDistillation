using UnityEngine;

namespace Scripts.Scenes.Village.Buildings.Production
{
    public interface IProductionController
    {
        void Add(string key, Coroutine coroutine);
        Coroutine FindByKey(string key);
        void Remove(string key);
    }
}
