using Scripts.Objects.Raw;
using Scripts.Objects.Raw.Load;
using Scripts.UI;
using Scripts.UI.Raw;
using Scripts.UI.Workshop.Craft;
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

        private Dictionary<string, RawObject> _rawData;
        public Dictionary<string, RawObject> RawData
        {
            get { return _rawData; }
        }

        public void InitRawListData(List<RawLoadObject> rawInfo)
        {
            var files = Resources.LoadAll<ObjectData>("Data/Raw");

            _rawData = new Dictionary<string, RawObject>();
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

                _rawData.Add(raw.Name, rawObj);
            }         
        }

        public void SetRawListData(string type, int count)
        {
            _rawData[type].Count += count;

            _rawUIController.RawTextEvent.Invoke(type);

            var menu = _uiController.FindByPart("CraftMenu");
            if (_uiController.FindByPart("CraftMenu") != null)
            {
                menu.GetComponent<CraftMenuUI>().PartGroup.SetPartsInfo();
            }
        }
    }
}
