using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.Craft.Order
{
    public class CraftCellsGroup : MonoBehaviour
    {
        public List<CraftCell> Cells { get; private set; }

        // ReSharper disable once UnusedMember.Local
        private void Start() { }

        public void SubscribeCellToList(CraftCell cell)
        {
            if (Cells == null)
            {
                Cells = new List<CraftCell>();
            }

            Cells.Add(cell);
        }
    }
}
