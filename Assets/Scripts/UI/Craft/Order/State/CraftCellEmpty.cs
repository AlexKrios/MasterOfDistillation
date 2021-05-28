using Assets.Scripts.UI.Craft.Order;
using UnityEngine;

namespace Assets.Scripts.Ui.Craft.Order.State
{
    public class CraftCellEmpty : ICraftCellState
    {
        private readonly CraftCell _craftCell;

        public CraftCellEmpty(CraftCell craftCell)
        {
            _craftCell = craftCell;
        }

        public void Enter()
        {
            Debug.Log("Enter Empty");

            _craftCell.ResetCell();
        }

        public void Click()
        {
            Debug.Log("Click Empty");
        }

        public void Exit()
        {
            Debug.Log("Exit Empty");
        }
    }
}
