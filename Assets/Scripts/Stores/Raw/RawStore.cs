using Assets.Scripts.Ui;
using Assets.Scripts.Ui.FullMenu.Common;
using Assets.Scripts.Ui.Raw;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Stores.Raw
{
    [UsedImplicitly]
    public class RawStore : IRawStore
    {
        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly IRawUiController _rawUiController;

        public Dictionary<string, IRaw> RawData { get; private set; }

        public void InitRawListData(List<RawLoadObject> rawInfo)
        {
            var files = Resources.LoadAll<ItemScriptable>("Data/Raw");

            RawData = new Dictionary<string, IRaw>();
            foreach (var raw in rawInfo)
            {
                var fileData = files.First(x => x.Name == raw.Name);
                //TODO создать фабрику и добавить в DI
                var rawObj = new RawObject
                {
                    Name = fileData.Name,

                    ItemType = fileData.ItemType,
                    RawType = (RawType)Enum.Parse(typeof(RawType), fileData.Name),

                    Count = raw.Count,

                    Settings = raw.Settings
                };

                RawData.Add(raw.Name, rawObj);
                _rawUiController.RawTextEvent.Invoke(raw.Name);
            }
        }

        public void SetRawListData(string type, int count)
        {
            RawData[type].Count += count;

            _rawUiController.RawTextEvent.Invoke(type);

            var menu = _uiController.FindByPart("Menu");
            if (menu != null)
                menu.GetComponent<IFullMenu>().Parts.SetPartsInfo();
        }
    }
}
