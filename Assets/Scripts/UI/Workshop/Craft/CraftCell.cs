using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop
{
    public class CraftCell : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<string, CraftCell> { }
    }
}
