using Scripts.Scenes.Main.Craft;
using Scripts.Scenes.Main.MainCamera;
using Scripts.UI;
using UnityEngine;
using Zenject;

namespace Scripts.Scenes.Main.Buildings.Workshop.UI
{
    public class WorkshopMenuButtons : MonoBehaviour
    {
        private IUiController _uiController;
        private IDisable _disable;
        private ICraftController _productionController;

        public GameObject menu;

        [Inject]
        public void Construct(IUiController uiController, IDisable disable, ICraftController productionController)
        {
            _productionController = productionController;
            _uiController = uiController;
            _disable = disable;
        }

        public void Close()
        {
            RemoveUiElement();
        }

        public void Create(int number)
        {
            var productionComponent = _uiController.ActiveBuilding.GetComponent<AbstractCraft>();
            productionComponent.IngridientCraft();

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
