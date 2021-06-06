using Assets.Scripts.MainCamera.Disable;
using UnityEngine;
using Zenject;

// ReSharper disable ClassNeverInstantiated.Global
#pragma warning disable 649

namespace Assets.Scripts.Ui.FullMenu.Common.Close
{
    public class CloseButton : MonoBehaviour
    {
        [Inject(Id = "MainCanvas")] private readonly RectTransform _mainCanvas;

        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly IDisable _disable;

        private IFullMenu _fullMenu;

        // ReSharper disable once UnusedMember.Local
        private void Awake()
        {
            _fullMenu = _uiController.FindByPart("Menu").GetComponent<IFullMenu>();
        }

        public void Click()
        {
            _mainCanvas.gameObject.SetActive(true);
            _uiController.Remove(_fullMenu.GameObject);

            _disable.Remove(DisableType.Camera);
        }
    }
}
