using System;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.Popup
{
    [Serializable]
    public class PopupObject
    {
        public string Name;

        public PopupType Type;
        public PopupSizeType Size;

        public string Text;

        public float? FadeTime;
    }
}
