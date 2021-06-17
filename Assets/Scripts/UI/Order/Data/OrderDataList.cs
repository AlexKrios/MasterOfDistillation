using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649

namespace Assets.Scripts.Ui.Order.Data
{
    [CreateAssetMenu(fileName = "OrderDataList", menuName = "Scriptable/Order Data", order = 51)]
    public class OrderDataList : ScriptableObject
    {
        [SerializeField] private List<OrderDataObject> _data;
        public List<OrderDataObject> Data => _data;
    }
}
