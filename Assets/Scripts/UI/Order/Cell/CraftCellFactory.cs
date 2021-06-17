using JetBrains.Annotations;
using System;
using UnityEngine;
using Zenject;

// ReSharper disable UnassignedField.Global

namespace Assets.Scripts.Ui.Order.Cell
{
    [UsedImplicitly]
    public class CraftCellFactory : IFactory<CraftCell> 
    {
        [Inject] private readonly DiContainer _container;
        [Inject] private readonly CraftGroupFactory.Settings _craftGroupSettings;

        [Inject] private readonly IUiController _uiController;

        public CraftCell Create()
        {
            var parent = _uiController.Find(_craftGroupSettings.Name).GetComponent<CraftGroup>().transform;

            var cellSettings = _craftGroupSettings.CraftCellSettings;

            var result = _container.InstantiatePrefabForComponent<CraftCell>(cellSettings.Prefab, parent);
            result.name = cellSettings.Name;

            return result;
        }

        [Serializable]
        public class Settings
        {
            public string Name;
            public GameObject Prefab;
        }
    }
}
