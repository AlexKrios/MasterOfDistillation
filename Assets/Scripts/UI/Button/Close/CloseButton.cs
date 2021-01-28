using Scripts.Scenes.Village;
using Scripts.Scenes.Village.Buildings.Production;
using Scripts.Scenes.Village.MainCamera;
using UnityEngine;

namespace Scripts.UI.Button.Close
{
    public class CloseButton : MonoBehaviour
    {
        private UiManager UiManager { get => GameManager.Instance.uiManager; }
        private IDisable Disable { get => RoomManager.Instance.disable; }
        public GameObject menu;

        public void RemoveUiElement()
        {
            Destroy(menu.gameObject);
            UiManager.RemoveUiElement(menu.name);
            UiManager.ActiveBuilding = null;

            Disable.Remove("BuildingSelect");
        }

        public void StartProduction() 
        {
            var productionComponent = UiManager.ActiveBuilding.GetComponent<IProduction>();
            UiManager.Add(productionComponent.StartProduction());
        }
    }
}
