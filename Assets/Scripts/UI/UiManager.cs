using Scripts.UI.Button;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.UI
{
    public class UiManager : MonoBehaviour
    {        
        public ButtonManager buttonManager;

        private Dictionary<string, GameObject> _uiElements = new Dictionary<string, GameObject>();
        
        private GameObject _activeBuilding;
        public GameObject ActiveBuilding 
        {
            get { return _activeBuilding; }
            set { _activeBuilding = value; }
        }

        public List<IEnumerator> test = new List<IEnumerator>();

        public void AddUiElement(string key, GameObject value)
        {      
            _uiElements.Add(key, value);
        }

        public GameObject FindUiElement(string key)
        {
            return _uiElements.FirstOrDefault(x => x.Key == key).Value;
        }

        public GameObject FindUiElementByPart(string part)
        {
            return _uiElements.FirstOrDefault(x => x.Key.Contains(part)).Value;
        }

        public void RemoveUiElement(string key)
        {
            _uiElements.Remove(key);
        }

        public void ClearUiElements()
        {
            _uiElements.Clear();
        }

        public void Add(IEnumerator coroutine)
        {
            test.Add(coroutine);
            StartCoroutine(coroutine);
        }
    }
}