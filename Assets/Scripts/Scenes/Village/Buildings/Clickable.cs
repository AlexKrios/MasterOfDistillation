using Scripts.Scenes.Village.Buildings.MainCamera;
using Scripts.Scenes.Village.MainCamera;
using Scripts.Scenes.Village.UI.Building;
using Scripts.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Scripts.Scenes.Village.Buildings
{
    public class Clickable : MonoBehaviour, IPointerClickHandler
    {
        private Camera _mainCamera;

        private IUiController _uiController;
        private ITarget _target;
        private IDisable _disable;        

        [Inject]
        private BuildingMenu.Factory _buildingMenuFactory;

        [Inject]
        public void Construct(ICameraController cameraController, IUiController uiController, ITarget target, IDisable disable)
        {
            _mainCamera = cameraController.MainCamera;

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
