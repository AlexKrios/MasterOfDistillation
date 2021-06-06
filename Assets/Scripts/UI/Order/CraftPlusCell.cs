using Assets.Scripts.Ui.FullMenu.Craft.Controller;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
// ReSharper disable UnusedMember.Local

#pragma warning disable 649

namespace Assets.Scripts.Ui.Order
{
    [UsedImplicitly]
    public class CraftPlusCell : MonoBehaviour, IPointerClickHandler
    {
        [Inject] private readonly CraftGroupFactory.Settings _craftGroupSettings;

        [Inject] private readonly IUiController _uiController;

        [Inject(Id = "SceneContext")] private Transform _sceneContext;

        private CraftGroup _craftGroup;

        private void Start()
        {
            _craftGroup = _uiController.Find(_craftGroupSettings.Name).GetComponent<CraftGroup>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            var craftCell = _sceneContext.GetComponent<ICraftController>();

            _craftGroup.CreateCell(craftCell.CraftCellCount);
            craftCell.CraftCellCount++;
        }

        [UsedImplicitly]
        public class Factory : PlaceholderFactory<CraftPlusCell> { }
    }
}
