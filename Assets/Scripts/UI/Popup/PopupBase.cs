using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable UnusedMember.Local

#pragma warning disable 649

namespace Assets.Scripts.Ui.Popup
{
    [UsedImplicitly]
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class PopupBase : MonoBehaviour
    {
        protected Text Text;

        protected float FadeTime;

        public void SetGameObjectName(string gameObjectName)
        {
            gameObject.name = gameObjectName;
        }

        public void SetText(string text)
        {
            Text.text = text;
        }

        public void SetFadeTime(float? fadeTime)
        {
            if (fadeTime != null)
                FadeTime = (float)fadeTime;

            FadeTime = 0.5f;
        }
    }
}
