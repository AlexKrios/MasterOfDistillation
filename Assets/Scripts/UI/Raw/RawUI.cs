using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.Raw
{
    public class RawUi : MonoBehaviour
    {
        public Image IronIcon;
        public Text IronText;

        public class Factory : PlaceholderFactory<RawUi> { }
    }
}
