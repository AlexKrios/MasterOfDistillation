using Assets.Scripts.Objects.Item.Raw;
using Assets.Scripts.Objects.Item.Raw.Load;
using Assets.Scripts.Scriptable;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Craft;
using Assets.Scripts.UI.Raw;
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
                //TODO создать фэктори и добавит в DI
                var rawObj = new RawObject
                {
                    Name = fileData.Name,

                    ItemType = fileData.ItemType,
                    RawType = (RawType)Enum.Parse(typeof(RawType), fileData.Name),

                    Count = raw.Count,

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
