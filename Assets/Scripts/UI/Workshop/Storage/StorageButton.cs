using UnityEngine;
using Zenject;

namespace Scripts.UI.Workshop.Storage
{
    public class StorageButton : MonoBehaviour
    {
        [Inject] private StorageMenuUI.Factory _storageMenuUI;

        public void Click()
        {
            _storageMenuUI.Create();
        }
    }
}
