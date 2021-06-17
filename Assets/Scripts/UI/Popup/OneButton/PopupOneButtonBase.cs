using JetBrains.Annotations;
using UnityEngine.UI;

// ReSharper disable UnusedMember.Local

#pragma warning disable 649

namespace Assets.Scripts.Ui.Popup.OneButton
{
    [UsedImplicitly]
    public class PopupOneButtonBase : PopupBase
    {
        protected Button Button;

        private void Awake()
        {
            var component = GetComponent<PopupOneButton>();

            Text = component.Text;
            Button = component.Button;
        }

        private void Start() { }
    }
}
