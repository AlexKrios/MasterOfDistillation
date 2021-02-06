using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.UI
{
    public class UiController : IUiController
    {
        private Dictionary<string, GameObject> _uiElements = new Dictionary<string, GameObject>();
        
        private GameObject _activeBuilding;
        public GameObject ActiveBuilding 
        {
            get { return _activeBuilding; }
            set { _activeBuilding = value; }
        }

        public void Add(string key, GameObject value)
        {      
            _uiElements.Add(key, value);
        }

        public GameObject Find(string key)
        {
            return _uiElements.FirstOrDefault(x => x.Key == key).Value;
        }

        public GameObject FindByPart(string part)
        {
            return _uiElements.FirstOrDefault(x => x.Key.Contains(part)).Value;
        }

        public void Remove(GameObject gameObject)
        {
            GameObject.Destroy(gameObject);
            _uiElements.Remove(gameObject.name);
        }

        public void Clear()
        {
            _uiElements.Clear();
        }
    }
}