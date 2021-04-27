using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop.Craft
{
    public class CraftButton : MonoBehaviour
    {
        [Inject] private CraftMenuUI.Factory _craftMenuUI;

        public void Click()
        {
            _craftMenuUI.Create();
        }
    }
}
