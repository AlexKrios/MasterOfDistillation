using Scripts.Objects.Product;
using Scripts.Objects.Raw;
using Scripts.Objects.Raw.Load;
using Scripts.UI;
using Scripts.UI.Raw;
using Scripts.UI.Craft;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Scripts.Stores.Raw
{
    public class RawStore : IRawStore
    {
        [Inject] private IUiController _uiController;
        [Inject] private IRawUIController _rawUIController;

        public Dictionary<string, RawObject> RawData { get; private set; }

        public void InitRawListData(List<RawLoadObject> rawInfo)
        {
            var files = Resources.LoadAll<ProductData>("Data/Raw");

            RawData = new Dictionary<string, RawObject>();
            foreach (var raw in rawInfo)
            {
                var fileData = files.First(x => x.Name == raw.Name);
                var rawObj = new RawObject
                {
                    Data = fileData,

                    Count = raw.Count,
                    Level = raw.Level,

                    Settings = raw.Settings
                };

                RawData.Add(raw.Name, rawObj);
            }         
        }

        public void SetRawListData(string type, int count)
        {
            RawData[type].Count += count;

            _rawUIController.RawTextEvent.Invoke(type);

            var menu = _uiController.FindByPart("CraftMenu");
            if (_uiController.FindByPart("CraftMenu") != null)
            {
                menu.GetComponent<CraftMenu>().PartGroup.SetPartsInfo();
            }
        }
    }
}
