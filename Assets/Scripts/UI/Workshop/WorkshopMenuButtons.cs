using Scripts.Common.Craft;
using Scripts.Scenes.Main.MainCamera;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop
{
    public class WorkshopMenuButtons : MonoBehaviour
    {
        [Inject] private IUiController _uiController;
        [Inject] private IDisable _disable;
        [Inject] private ICraftController _craftController;

        public GameObject menu;

        public void Close()
        {
            RemoveUiElement();
        }

        public void Create(int number)
        {
            var craft = _uiController.ActiveBuilding.GetComponent<AbstractCraft>();
            craft.CraftComponent();

            RemoveUiElement();
        }

        public void Stop()
        {
            var coroutine = _craftController.FindByKey("Test");
            StopCoroutine(coroutine);
            _craftController.Remove("Test");

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
