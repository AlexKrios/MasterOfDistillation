using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Storage
{
    public class StorageButton : MonoBehaviour
    {
        [Inject] private readonly StorageMenuUi.Factory _storageMenuUi;

        public void Click()
        {
            _storageMenuUi.Create();
        }
    }
}
