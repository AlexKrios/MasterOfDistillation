using Scripts.Scenes.Village.MainCamera;
using Scripts.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.Scenes.Village.Buildings
{
    public class Clickable : MonoBehaviour, IPointerClickHandler
    {
        private UiManager UiManager { get => GameManager.Instance.uiManager; }
        private ITarget Target { get => RoomManager.Instance.target; }
        private IDisable Disable { get => RoomManager.Instance.disable; }
        private Camera _mainCamera { get => RoomManager.Instance.mainCamera; }

        public void OnPointerClick(PointerEventData data)
        {
            var targetGO = data.pointerCurrentRaycast.gameObject;
            var targetRenderer = targetGO.GetComponent<Renderer>().bounds.center;
            var targetPos = new Vector3(targetRenderer.x, _mainCamera.transform.position.y, targetRenderer.z);

            Target.Position = targetPos;
            Disable.Add("BuildingSelect");

            UiManager.ActiveBuilding = targetGO;
            UiManager.buttonManager.CreateHorizontalGroup(targetGO.name);
        }
    }
}
