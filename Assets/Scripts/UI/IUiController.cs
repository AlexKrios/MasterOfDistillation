using UnityEngine;

namespace Scripts.UI
{
    public interface IUiController
    {
        GameObject ActiveBuilding { get; set; }

        void Add(string key, GameObject value);
        GameObject Find(string key);
        GameObject FindByPart(string part);
        void Remove(GameObject gameObject);
        void Clear();
    }
}
