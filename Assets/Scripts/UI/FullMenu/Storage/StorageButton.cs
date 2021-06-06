using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Ui.FullMenu.Storage
{
    [UsedImplicitly]
    public class StorageButton : MonoBehaviour
    {
        [Inject] private readonly StorageMenu.Factory _storageMenuFactory;

        public void Click()
        {
            _storageMenuFactory.Create();
        }
    }
}
