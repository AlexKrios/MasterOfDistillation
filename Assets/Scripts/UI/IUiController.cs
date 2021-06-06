using UnityEngine;

namespace Assets.Scripts.Ui
{
    public interface IUiController
    {
        void Add(string key, GameObject value);
        void GetAll();
        GameObject Find(string key);
        GameObject FindByPart(string key);
        void Remove(GameObject gameObject);
    }
}
