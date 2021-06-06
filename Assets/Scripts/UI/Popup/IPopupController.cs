using UnityEngine;

namespace Assets.Scripts.Ui.Popup
{
    public interface IPopupController
    {
        void Add(string key, GameObject value);
        void GetAll();
        GameObject Find(string key);
        GameObject FindByPart(string key);
        void Remove(GameObject gameObject);
    }
}
