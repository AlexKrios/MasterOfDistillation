using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable UnusedMember.Local

#pragma warning disable 649

namespace Assets.Scripts.Ui.Popup.TwoButton
{
    [UsedImplicitly]
    public class PopupTwoButton : MonoBehaviour
    {
        [SerializeField] private Text _text;
        public Text Text => _text;

        [SerializeField] private Button _leftButton;
        public Button LeftButton => _leftButton;

        [SerializeField] private Button _rightButton;
        public Button RightButton => _rightButton;

        private void Start() { }
    }
}
