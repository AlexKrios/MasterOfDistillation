using Scripts.Scenes.Main.MainCamera;
using Scripts.UI;
using UnityEngine;
using Zenject;

namespace Scripts.Scenes.Main.Buildings.Workshop.UI
{
    public class WorkshopMenu : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<string, WorkshopMenu> { }
    }

    public class WorkshopMenuFactory : IFactory<string, WorkshopMenu> 
    {
        private DiContainer _container;
        private IUiController _uiController;
        private IDisable _disable;

        private Transform _mainCanvas;

        public WorkshopMenuFactory(DiContainer container, IUiController uiController, IDisable disable, [Inject(Id = "MainCanvas")] RectTransform mainCanvas)
        {
            _container = container;
            _uiController = uiController;
            _disable = disable;

            _mainCanvas = mainCanvas.gameObject.transform;
        }

        public WorkshopMenu Create(string targetName)
        {
            var name = "BuildingMenu" + targetName;
            var uiElementSimilar = _uiController.FindByPart("BuildingMenu");

            if (uiElementSimilar != null)
            {                
                _uiController.Remove(uiElementSimilar);
                _disable.Remove("BuildingSelect");
            }

            var prefab = Resources.Load("UI/WorkshopMenu");
            var horMenu = _container.InstantiatePrefabForComponent<WorkshopMenu>(prefab, _mainCanvas);
            horMenu.name = name;

            _uiController.Add(horMenu.name, horMenu.gameObject);

            return horMenu;
        }
    }
}
