using Zenject;

namespace Assets.Scripts.Ui.Order.State
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
            _craftCell.ResetCell();
        }

        public void Click() { }

        public void Exit() { }

        public class Factory : PlaceholderFactory<CraftCell, CraftCellEmpty> { }
    }
}
