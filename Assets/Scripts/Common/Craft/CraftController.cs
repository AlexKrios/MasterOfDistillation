using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Common.Craft
{
    public class CraftController : ICraftController
    {
        private Dictionary<string, Coroutine> _craftList = new Dictionary<string, Coroutine>();
        private string _activeCraft;
        public string ActiveCraft
        {
            get { return _activeCraft; }
            set { _activeCraft = value; }
        }

        private string _activeQuality;
        public string ActiveQuality
        {
            get { return _activeQuality; }
            set { _activeQuality = value; }
        }

        public void Add(string key, Coroutine coroutine)
        {
            _craftList.Add(key, coroutine);
        }

        public Coroutine FindByKey(string key)
        {
            return _craftList[key];
        }

        public void Remove(string key)
        {
            _craftList.Remove(key);
        }

        public void ResetActive()
        {
            _activeCraft = null;
            _activeQuality = null;
        }
    }
}
