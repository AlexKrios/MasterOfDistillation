using Scripts.Common.Craft.Action;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI.Craft.Order
{
    public class CraftCell : MonoBehaviour, IPointerClickHandler
    {
        [Inject] private CraftAction _craftAction;

        [SerializeField] private CraftCellsGroup _craftCellsGroup;

        [Header("Product cell info")]
        [SerializeField] private Image _icon;
        [SerializeField] private Text _timer;

        public bool IsBusy { get; set; }

        private void Start() 
        {
            _craftCellsGroup.SubscribeCellToList(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            
        }   

        private void SetCellIcon(Sprite icon)
        {
            _icon.sprite = icon;
        }

        private void SetCellName(string timer)
        {
            _timer.text = timer;
        }
    }
}
