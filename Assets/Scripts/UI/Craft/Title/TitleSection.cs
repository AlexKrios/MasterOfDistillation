using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

#pragma warning disable 649

namespace Assets.Scripts.Ui.Craft.Title
{
    [UsedImplicitly]
    public class TitleSection : MonoBehaviour, ITitleSection
    {
        #region Links

        [SerializeField] private Text _text;
        public string Text
        {
            get => _text.text;
            set => _text.text = value;
        }

        #endregion

        // ReSharper disable once UnusedMember.Local
        private void Start() { }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<TitleSection> { }
    }
}
