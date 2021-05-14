using Assets.Scripts.Scenes.Main.MainCamera.Disable;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
#pragma warning disable 649

namespace Assets.Scripts.UI.Craft.Close
{
    public class CloseButton : MonoBehaviour
    {
        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly IDisable _disable;
        [Inject] private readonly CraftMenuUiFactory.Settings _settings;

        [SerializeField] private CraftMenu _menu;
        public CraftMenu Menu => _menu;

        [Header("Components")]
        [SerializeField] private Image _icon;
        public Image Icon => _icon;

        // ReSharper disable once UnusedMember.Local
        private void Start() { }

        public void Click()
        {
            _uiController.Remove(_menu.gameObject);
            _disable.Remove(_settings.Name);
        }
    }
}
