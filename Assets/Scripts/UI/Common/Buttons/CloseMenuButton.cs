using Scripts.Scenes.Main.MainCamera;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Common.Buttons
{
    public class CloseMenuButton : AbstractButtons 
    {
        [Inject] private IDisable _disable;

        public override void CloseMenu(GameObject menu)
        {
            base.CloseMenu(menu);

            _uiController.ActiveBuilding = null;
            _disable.Remove("WorkshopSelect");
        }
    }
}
