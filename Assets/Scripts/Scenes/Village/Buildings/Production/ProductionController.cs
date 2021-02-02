using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Scenes.Village.Buildings.Production
{
    public class ProductionController : IProductionController
    {
        private Dictionary<string, Coroutine> _coroutines = new Dictionary<string, Coroutine>();

        private void Start() { }

        public void Add(string key, Coroutine coroutine)
        {
            _coroutines.Add(key, coroutine);
        }

        public Coroutine FindByKey(string key)
        {
            return _coroutines[key];
        }

        public void Remove(string key)
        {
            _coroutines.Remove(key);
        }
    }
}
