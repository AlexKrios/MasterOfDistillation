using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Ui.Raw
{
    [UsedImplicitly]
    public class RawUi : MonoBehaviour
    {
        public Image IronIcon;
        public Text IronText;

        public class Factory : PlaceholderFactory<RawUi> { }
    }
}
