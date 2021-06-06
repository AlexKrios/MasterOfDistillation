using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts.Stores.Product
{
    [CreateAssetMenu(fileName = "ProductStoreData", menuName = "Product ItemsDictionary Data", order = 51)]
    public class ProductStoreSettings : ScriptableObject
    {
        [SerializeField] private List<ProductStoreData> _data;
        public List<ProductStoreData> Data => _data;
    }
}
