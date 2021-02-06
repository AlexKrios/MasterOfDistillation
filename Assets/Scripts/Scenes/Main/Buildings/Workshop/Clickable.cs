using Scripts.Scenes.Main.Buildings.Workshop.UI;
using Scripts.Scenes.Main.MainCamera;
using Scripts.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Scripts.Scenes.Main.Buildings.Workshop
{
    public class Clickable : MonoBehaviour, IPointerClickHandler
    {
        private Camera _mainCamera;

        private IUiController _uiController;
        private ITarget _target;
        private IDisable _disable;        

        [Inject] private WorkshopMenu.Factory _buildingMenuFactory;

        [Inject]
        public void Construct([Inject(Id = "MainCamera")] Transform mainCamera, IUiController uiController, ITarget target, IDisable disable)
        {
            _mainCamera = mainCamera.GetComponent<Camera>();

            _uiController = uiController;
            _target = target;
            _disable = disable;            
        }

        public void OnPointerClick(PointerEventData data)
        {
            var targetGO = data.pointerCurrentRaycast.gameObject;
            var targetRenderer = targetGO.GetComponent<Renderer>().bounds.center;
            var targetPos = new Vector3(targetRenderer.x, _mainCamera.transform.position.y, targetRenderer.z);

            _target.Position = targetPos;
            _disable.Add("BuildingSelect");

            _uiController.ActiveBuilding = targetGO;
            _buildingMenuFactory.Create(targetGO.name);
        }
    }
}
