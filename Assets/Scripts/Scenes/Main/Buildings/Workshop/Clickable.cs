using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Assets.Scripts.Scenes.Main.Buildings.Workshop
{
    public class Clickable : MonoBehaviour, IPointerClickHandler
    {
        // ReSharper disable once NotAccessedField.Local
        private Camera _mainCamera;

        //[Inject] private readonly IUiController _uiController;
        //[Inject] private readonly ITarget _target;
        //[Inject] private readonly IDisable _disable;        

        [Inject]
        public void Construct([Inject(Id = "MainCamera")] Transform mainCamera)
        {
            _mainCamera = mainCamera.GetComponent<Camera>();           
        }

        public void OnPointerClick(PointerEventData data)
        {
            //var targetGO = data.pointerCurrentRaycast.gameObject;
            //var targetRenderer = targetGO.GetComponent<Renderer>().bounds.center;
            //var targetPos = new Vector3(targetRenderer.x, _mainCamera.transform.position.y, targetRenderer.z);

            //_target.Position = targetPos;
            //_disable.Add("WorkshopSelect");

            //_uiController.ActiveBuilding = targetGO;            

            //_workshopMenuFactory.Create(targetGO.name);
        }
    }
}
