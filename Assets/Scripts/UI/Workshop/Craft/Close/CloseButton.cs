using Scripts.Scenes.Main.MainCamera;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Workshop.Craft.Close
{
    public class CloseButton : MonoBehaviour
    {
        [Inject] private IUiController _uiController;
        [Inject] private IDisable _disable;
        [Inject] private CraftMenuUIFactory.Settings _settings;

        [SerializeField] private CraftMenuUI _menu;
        public CraftMenuUI Menu { get => _menu; }

        [Header("Components")]
        [SerializeField] private Image _icon;
        public Image Icon { get => _icon; }

        private void Start() { }

        public void Click()
        {
            _uiController.Remove(_menu.gameObject);
            _disable.Remove(_settings.Name);
        }
    }
}
