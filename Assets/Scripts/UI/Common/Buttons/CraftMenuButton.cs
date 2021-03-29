using Scripts.Common.Craft;
using Scripts.Scenes.Main.MainCamera;
using Scripts.UI.Workshop.Craft;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Common.Buttons
{
    public class CraftMenuButton : AbstractButtons 
    {
        [Inject] private IDisable _disable;

        [Inject] private CraftMenuUI.Factory _craftMenuUI;

        public void CraftMenu(GameObject menu)
        {
            var craftType = _uiController.ActiveBuilding.GetComponent<ICraft>();
            _craftMenuUI.Create(craftType);

            CloseMenu(menu);
            _disable.Remove("WorkshopSelect");
        }
    }
}
