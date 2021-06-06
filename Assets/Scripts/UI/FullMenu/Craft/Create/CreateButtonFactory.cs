using Assets.Scripts.Ui.FullMenu.Common;
using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.FullMenu.Craft.Create
{
    [UsedImplicitly]
    public class CreateButtonFactory : IFactory<CreateButton>
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly CraftMenuFactory.Settings _craftMenuSettings;

        [Inject] private readonly IUiController _uiController;

        public CreateButton Create()
        {
            var createSettings = _craftMenuSettings.CreateButtonSettings;
            var parent = _uiController.Find(_craftMenuSettings.Name).GetComponent<IFullMenu>().Product.Transform;

            var button = _container.InstantiatePrefabForComponent<CreateButton>(createSettings.Prefab, parent);
            button.name = createSettings.Name;

            button.transform.SetSiblingIndex(2);

            return button;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;
        }
    }
}
