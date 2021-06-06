using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Ui.Popup
{
    [UsedImplicitly]
    public class PopupController : IPopupController
    {
        private readonly Dictionary<string, GameObject> _popupElements;

        public PopupController()
        {
            _popupElements = new Dictionary<string, GameObject>();
        }

        public void Add(string key, GameObject value)
        {
            _popupElements.Add(key, value);
        }

        public void GetAll()
        {
            foreach (var element in _popupElements)
            {
                Debug.Log(element.Key);
            }
        }

        public GameObject Find(string key)
        {
            return _popupElements.FirstOrDefault(x => x.Key == key).Value;
        }

        public GameObject FindByPart(string key)
        {
            return _popupElements.FirstOrDefault(x => x.Key.Contains(key)).Value;
        }

        public void Remove(GameObject gameObject)
        {
            // ReSharper disable once AccessToStaticMemberViaDerivedType
            GameObject.Destroy(gameObject);
            _popupElements.Remove(gameObject.name);
        }
    }
}