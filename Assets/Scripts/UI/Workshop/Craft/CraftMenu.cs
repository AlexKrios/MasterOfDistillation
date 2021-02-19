using Scripts.Scenes.Main.MainCamera;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop
{
    public class CraftMenu : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<string, CraftMenu> { }
    }

    public class CraftMenuFactory : IFactory<string, CraftMenu> 
    {
        private DiContainer _container;
        [Inject] private IUiController _uiController;
        [Inject] private IDisable _disable;

        private Transform _mainCanvas;

        public CraftMenuFactory(DiContainer container, [Inject(Id = "MainCanvas")] RectTransform mainCanvas)
        {
            _container = container;

            _mainCanvas = mainCanvas.gameObject.transform;
        }

        public CraftMenu Create(string targetName)
        {
            var name = "BuildingMenu" + targetName;
            var uiElementSimilar = _uiController.FindByPart("BuildingMenu");

            if (uiElementSimilar != null)
            {
                _uiController.Remove(uiElementSimilar);
                _disable.Remove("BuildingSelect");
            }

            var prefab = Resources.Load("UI/WorkshopMenu");
            var horMenu = _container.InstantiatePrefabForComponent<CraftMenu>(prefab, _mainCanvas);
            horMenu.name = name;

            _uiController.Add(horMenu.name, horMenu.gameObject);

            return horMenu;
        }
    }
}
