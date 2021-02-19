using Scripts.Scenes.Main.MainCamera;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop
{
    public class WorkshopMenu : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<string, WorkshopMenu> { }
    }

    public class WorkshopMenuFactory : IFactory<string, WorkshopMenu> 
    {
        private DiContainer _container;
        [Inject] private IUiController _uiController;
        [Inject] private IDisable _disable;

        private Transform _mainCanvas;

        public WorkshopMenuFactory(DiContainer container, [Inject(Id = "MainCanvas")] RectTransform mainCanvas)
        {
            _container = container;

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
