using Scripts.Common.Craft;
using Scripts.Scenes.Main.MainCamera;
using Scripts.UI.Workshop.Craft;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop
{
    public class WorkshopMenuButtons : MonoBehaviour
    {
        [Inject] private IUiController _uiController;        
        [Inject] private ICraftController _craftController;
        [Inject] private IDisable _disable;

        [Inject] private CraftMenuUI.Factory _craftMenuUI;

        public GameObject menu;

        public void Close()
        {
            RemoveUiElement();
            _uiController.ActiveBuilding = null;
        }

        public void Create()
        {
            var craftType = _uiController.ActiveBuilding.GetComponent<ICraft>();
            _craftMenuUI.Create(craftType);

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

            _disable.Remove("WorkshopSelect");
        }
    }
}
