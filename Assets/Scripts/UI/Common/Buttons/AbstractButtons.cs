using UnityEngine;
using Zenject;

namespace Scripts.UI.Common.Buttons
{
    public class AbstractButtons : MonoBehaviour
    {
        [Inject] protected IUiController _uiController;

        public virtual void CloseMenu(GameObject menu)
        {
            _uiController.Remove(menu);            
        }
    }
}
