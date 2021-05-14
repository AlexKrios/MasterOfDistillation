using UnityEngine;
using Zenject;

namespace Scripts.UI.Craft
{
    public class CraftButton : MonoBehaviour
    {
        [Inject] private CraftMenu.Factory _craftMenuUI;

        public void Click()
        {
            _craftMenuUI.Create();
        }
    }
}
