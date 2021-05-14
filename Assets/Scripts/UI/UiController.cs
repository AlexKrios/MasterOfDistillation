using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UiController : IUiController
    {
        private readonly Dictionary<string, GameObject> _uiElements;

        public GameObject ActiveBuilding { get; set; }

        public UiController()
        {
            _uiElements = new Dictionary<string, GameObject>();
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
            // ReSharper disable once AccessToStaticMemberViaDerivedType
            GameObject.Destroy(gameObject);
            _uiElements.Remove(gameObject.name);
        }

        public void Clear()
        {
            _uiElements.Clear();
        }
    }
}