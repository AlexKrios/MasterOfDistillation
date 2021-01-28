using Scripts.Scenes.Village;
using Scripts.Scenes.Village.MainCamera;
using UnityEngine;

namespace Scripts.UI.Button
{
    public class ButtonManager : MonoBehaviour
    {
        private UiManager UiManager { get => GameManager.Instance.uiManager; }
        private IDisable Disable { get => RoomManager.Instance.disable; }
        private GameObject _mainCanvas { get => RoomManager.Instance.mainCanvas; }

        public void CreateHorizontalGroup(string targetName)
        {
            var name = "BuildingMenu" + targetName;
            var uiElementSimilar = UiManager.FindUiElementByPart("BuildingMenu");

            if (uiElementSimilar != null)
            {
                Destroy(uiElementSimilar.gameObject);
                UiManager.RemoveUiElement(uiElementSimilar.name);

                Disable.Remove("BuildingSelect");
            }

            var prefab = Resources.Load("UI/BuildingMenu");
            var horMenu = Instantiate(prefab as GameObject, _mainCanvas.transform);
            horMenu.name = name;
            
            UiManager.AddUiElement(horMenu.name, horMenu);
        }
    }
}