using Assets.Scripts.MainCamera.Disable;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

#pragma warning disable 649

namespace Assets.Scripts.Ui.Order.Result
{
    [UsedImplicitly]
    public class ResultButton : MonoBehaviour
    {
        [Inject] private readonly ResultCanvasFactory.Settings _resultCanvasSettings;

        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly IDisable _disable;

        [Inject(Id = "MainCanvas")] private readonly RectTransform _mainCanvas;

        public void Click()
        {
            _mainCanvas.gameObject.SetActive(true);

            var result = _uiController.Find(_resultCanvasSettings.Name);
            _uiController.Remove(result);

            _disable.Remove(DisableType.Camera);
        }
    }
}
