using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Craft
{
    public class CraftButton : MonoBehaviour
    {
        [Inject] private readonly CraftMenu.Factory _craftMenuUi;

        public void Click()
        {
            _craftMenuUi.Create();
        }
    }
}
