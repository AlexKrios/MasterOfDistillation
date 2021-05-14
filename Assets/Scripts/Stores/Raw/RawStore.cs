using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Objects.Product.Data;
using Assets.Scripts.Objects.Raw;
using Assets.Scripts.Objects.Raw.Load;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Craft;
using Assets.Scripts.UI.Raw;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Stores.Raw
{
    public class RawStore : IRawStore
    {
        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly IRawUiController _rawUiController;

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

            _rawUiController.RawTextEvent.Invoke(type);

            var menu = _uiController.FindByPart("CraftMenu");
            if (_uiController.FindByPart("CraftMenu") != null)
            {
                menu.GetComponent<CraftMenu>().PartGroup.SetPartsInfo();
            }
        }
    }
}
