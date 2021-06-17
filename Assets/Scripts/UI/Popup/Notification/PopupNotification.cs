using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable UnusedMember.Local

#pragma warning disable 649

namespace Assets.Scripts.Ui.Popup.Notification
{
    [UsedImplicitly]
    public class PopupNotification : MonoBehaviour
    {
        [SerializeField] private Text _text;
        public Text Text => _text;

        private void Start() { }
    }
}
