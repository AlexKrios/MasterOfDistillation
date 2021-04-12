using Scripts.Common.Craft;
using Scripts.Scenes.Main.MainCamera;
using Scripts.UI;
using Scripts.UI.Workshop;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Scripts.Scenes.Main.Buildings.Workshop
{
    public class Clickable : MonoBehaviour, IPointerClickHandler
    {
        private Camera _mainCamera;

        [Inject] private IUiController _uiController;
        [Inject] private ITarget _target;
        [Inject] private IDisable _disable;        

        [Inject] private WorkshopMenu.Factory _workshopMenuFactory;

        [Inject]
        public void Construct([Inject(Id = "MainCamera")] Transform mainCamera)
        {
            _mainCamera = mainCamera.GetComponent<Camera>();           
        }

        public void OnPointerClick(PointerEventData data)
        {
            var targetGO = data.pointerCurrentRaycast.gameObject;
            var targetRenderer = targetGO.GetComponent<Renderer>().bounds.center;
            var targetPos = new Vector3(targetRenderer.x, _mainCamera.transform.position.y, targetRenderer.z);

            _target.Position = targetPos;
            _disable.Add("WorkshopSelect");

            _uiController.ActiveBuilding = targetGO;            

            _workshopMenuFactory.Create(targetGO.name);
        }
    }
}
