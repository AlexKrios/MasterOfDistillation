using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable UnusedMember.Local

#pragma warning disable 649

namespace Assets.Scripts.Ui.Popup.OneButton
{
    [UsedImplicitly]
    public class PopupOneButton : MonoBehaviour
    {
        [SerializeField] private Text _text;
        public Text Text => _text;

        [SerializeField] private Button _button;
        public Button Button => _button;

        private void Start() { }
    }
}
