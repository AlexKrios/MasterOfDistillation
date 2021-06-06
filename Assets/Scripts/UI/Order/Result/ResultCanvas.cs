using Assets.Scripts.Objects.Item.Craft;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

#pragma warning disable 649

namespace Assets.Scripts.Ui.Order.Result
{
    [UsedImplicitly]
    public class ResultCanvas : MonoBehaviour
    {
        // ReSharper disable once UnusedMember.Local
        private void Start()
        { 
            GetComponent<Canvas>().worldCamera = Camera.main;
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<CraftObject, ResultCanvas> { }
    }
}
