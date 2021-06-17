using JetBrains.Annotations;
using UnityEngine.UI;

// ReSharper disable UnusedMember.Local

#pragma warning disable 649

namespace Assets.Scripts.Ui.Popup.TwoButton
{
    [UsedImplicitly]
    public abstract class PopupTwoButtonBase : PopupBase
    {
        protected Button LeftButton;
        protected Button RightButton;

        private void Awake()
        {
            var component = GetComponent<PopupTwoButton>();

            Text = component.Text;
            LeftButton = component.LeftButton;
            RightButton = component.RightButton;
        }
    }
}
