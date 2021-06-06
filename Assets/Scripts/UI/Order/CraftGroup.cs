using Assets.Scripts.Ui.FullMenu.Craft.Controller;
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
// ReSharper disable UnusedMember.Local
// ReSharper disable PossibleNullReferenceException

namespace Assets.Scripts.Ui.Order
{
    [UsedImplicitly]
    public class CraftGroup : MonoBehaviour
    {
        [Inject] private readonly CraftCell.Factory _craftCellFactory;
        [Inject] private readonly CraftPlusCell.Factory _craftPlusCellFactory;
        [Inject] private readonly CraftGroupFactory.Settings _craftGroupSettings;

        [Inject(Id = "SceneContext")] private Transform _sceneContext;

        public List<CraftCell> Cells { get; private set; }

        private void Awake()
        {
            if (Cells == null)
                Cells = new List<CraftCell>();
        }

        private void Start()
        {
            InitCells();
        }

        private void InitCells()
        {
            if (Cells != null)
                RemoveCells();

            var craftCellCount = _sceneContext.GetComponent<ICraftController>().CraftCellCount;
            for (var i = 0; i < craftCellCount; i++)
            {
                CreateCell(i);
            }

            CreatePlusCell();
        }

        private void CreatePlusCell()
        {
            _craftPlusCellFactory.Create();

            SetGroupWidth();
        }

        public void CreateCell(int index)
        {
            var cell = _craftCellFactory.Create();
            cell.name = $"{_craftGroupSettings.CraftCellSettings.Name}{index + 1}";
            cell.Id = index;
            cell.transform.SetSiblingIndex(index);

            SetGroupWidth();

            Cells.Add(cell);
        }

        private void RemoveCells()
        {
            foreach (var cell in Cells)
                Destroy(cell.gameObject);
        }

        private void SetGroupWidth()
        {
            var width = 150f * Cells.Count + 25f * (Cells.Count - 1) + 100f;
            var rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(width, rectTransform.sizeDelta.y);
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<CraftGroup> { }
    }
}
