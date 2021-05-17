using UnityEngine;

namespace Assets.Scripts.UI
{
    public interface IUiController
    {
        void Add(string key, GameObject value);
        GameObject Find(string key);
        GameObject FindByPart(string part);
        void Remove(GameObject gameObject);
        void Clear();
    }
}
