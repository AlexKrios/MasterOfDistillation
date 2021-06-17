using Assets.Scripts.Ui.Order.Data;
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Stores.Craft
{
    [UsedImplicitly]
    public class CraftStore : ICraftStore
    {
        public int CellCount { get; set; }
        private readonly List<OrderDataObject> _buyData;

        public CraftStore()
        {
            if (Resources.Load("Data/Craft/OrderData") is OrderDataList orderData)
                _buyData = orderData.Data;

            CellCount = 1;
        }

        public OrderDataObject GetCurrentData()
        {
            return _buyData[CellCount];
        }
    }
}
