using Assets.Scripts.Common.Craft;
using Assets.Scripts.Objects.Craft;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;
#pragma warning disable 649

namespace Assets.Scripts.UI.Craft.Order
{
    //TODO Переделать флаги на интерфейсы
    public class CraftCell : MonoBehaviour, IPointerClickHandler
    {
        private ICraftController _craftController;

        [SerializeField] private CraftCellsGroup _craftCellsGroup;

        [Header("Product cell info")]
        [SerializeField] private Image _icon;
        [SerializeField] private Text _timer;

        private int _id;

        public bool IsBusy { get; set; }
        public bool IsComplete { get; set; }

        [Inject]
        private void Construct([Inject(Id = "SceneContext")] Transform sceneContext)
        {
            _craftController = sceneContext.GetComponent<ICraftController>();
        }

        // ReSharper disable once UnusedMember.Local
        private void Start() 
        {
            _craftCellsGroup.SubscribeCellToList(this);
            _id = _craftCellsGroup.Cells.Count - 1;

            ResetCell();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (IsComplete)
            {
                return;
            }

            _craftController.CompleteCraft(_id);

            ResetCell();
        }

        public void SetCellInfo(CraftObject craftObject)
        {
            var itemData = craftObject.Item.Data;

            SetCellIcon(itemData.Icon);
        }

        public void SetCellIcon(Sprite icon)
        {
            _icon.color = new Color(1, 1, 1, 1);
            _icon.sprite = icon;
        }
        private void ResetCellIcon()
        {
            _icon.color = new Color(1, 1, 1, 0);
            _icon.sprite = null;            
        }

        private void ResetCell()
        {
            ResetCellIcon();
            SetCellTimer(null);
        }

        public void SetCellTimer(string timer)
        {
            _timer.text = timer;
        }
    }
}
