using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Ui
{
    [UsedImplicitly]
    public class UiController : IUiController
    {
        private readonly Dictionary<string, GameObject> _uiElements;

        public UiController()
        {
            _uiElements = new Dictionary<string, GameObject>();
        }

        public void Add(string key, GameObject value)
        {
            _uiElements.Add(key, value);
        }

        public void GetAll()
        {
            foreach (var element in _uiElements)
            {
                Debug.Log(element.Key);
            }
        }

        public GameObject Find(string key)
        {
            return _uiElements.FirstOrDefault(x => x.Key == key).Value;
        }

        public GameObject FindByPart(string key)
        {
            return _uiElements.FirstOrDefault(x => x.Key.Contains(key)).Value;
        }

        public void Remove(GameObject gameObject)
        {
            // ReSharper disable once AccessToStaticMemberViaDerivedType
            GameObject.Destroy(gameObject);
            _uiElements.Remove(gameObject.name);
        }
    }
}