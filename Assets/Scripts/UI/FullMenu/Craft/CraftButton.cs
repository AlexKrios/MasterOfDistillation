using UnityEngine;
using Zenject;

// ReSharper disable ClassNeverInstantiated.Global

namespace Assets.Scripts.Ui.FullMenu.Craft
{
    public class CraftButton : MonoBehaviour
    {
        [Inject] private readonly CraftMenu.Factory _craftMenu;

        public void Click()
        {
            _craftMenu.Create();
        }
    }
}
