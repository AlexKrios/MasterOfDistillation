using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Raw
{
    public class RawUI : MonoBehaviour
    {
        public Image IronIcon;
        public Text IronText;

        public class Factory : PlaceholderFactory<RawUI> { }
    }
}
