using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Scenes.Main.Craft
{
    public class CraftController : ICraftController
    {
        private Dictionary<string, Coroutine> _coroutines = new Dictionary<string, Coroutine>();

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
