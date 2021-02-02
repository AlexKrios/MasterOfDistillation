using Scripts.Scenes.Village.Buildings.Production;
using Scripts.Scenes.Village.MainCamera;
using Scripts.UI;
using UnityEngine;
using Zenject;

namespace Scripts.Scenes.Village.UI.Building
{
    public class BuildingButtons : MonoBehaviour
    {
        private IUiController _uiController;
        private IDisable _disable;
        private IProductionController _productionController;

        public GameObject menu;

        [Inject]
        public void Construct(IUiController uiController, IDisable disable, IProductionController productionController)
        {
            _productionController = productionController;
            _uiController = uiController;
            _disable = disable;
        }

        public void Close()
        {
            RemoveUiElement();
        }

        public void Create()
        {
            var productionComponent = _uiController.ActiveBuilding.GetComponent<AbstractProduction>();
            productionComponent.StartProduction();

            RemoveUiElement();
        }

        public void Stop()
        {
            var coroutine = _productionController.FindByKey("Test");
            StopCoroutine(coroutine);
            _productionController.Remove("Test");

            RemoveUiElement();
        }

        private void RemoveUiElement()
        {
            _uiController.Remove(menu);
            _uiController.ActiveBuilding = null;

            _disable.Remove("BuildingSelect");
        }
    }
}
