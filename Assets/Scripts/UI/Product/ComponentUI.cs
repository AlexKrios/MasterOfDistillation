using UnityEngine;
using Zenject;

namespace Scripts.UI.Product
{
    public class ComponentUI : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<ComponentUI> { }
    }
}
