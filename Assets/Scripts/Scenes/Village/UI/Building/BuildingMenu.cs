using Scripts.Scenes.Village.MainCamera;
using Scripts.UI;
using UnityEngine;
using Zenject;

namespace Scripts.Scenes.Village.UI.Building
{
    public class BuildingMenu : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<string, BuildingMenu> { }
    }

    public class BuildingMenuFactory : IFactory<string, BuildingMenu> 
    {
        private DiContainer _container;
        private IUiController _uiController;
        private IDisable _disable;

        public BuildingMenuFactory(DiContainer container, IUiController uiController, IDisable disable)
        {
            _container = container;
            _uiController = uiController;
            _disable = disable;
        }

        public BuildingMenu Create(string targetName)
        {
            var name = "BuildingMenu" + targetName;
            var uiElementSimilar = _uiController.FindByPart("BuildingMenu");

            if (uiElementSimilar != null)
            {                
                _uiController.Remove(uiElementSimilar);
                _disable.Remove("BuildingSelect");
            }

            var prefab = Resources.Load("UI/BuildingMenu");
            var horMenu = _container.InstantiatePrefabForComponent<BuildingMenu>(prefab, _uiController.MainCanvas.transform);
            horMenu.name = name;

            _uiController.Add(horMenu.name, horMenu.gameObject);

            return horMenu;
        }
    }
}
