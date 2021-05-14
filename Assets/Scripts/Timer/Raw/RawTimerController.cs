using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Stores.Raw;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Timer.Raw 
{
    public class RawTimerController : IRawTimerController
    {
        [Inject] private IRawStore _rawStore;

        public Dictionary<string, Coroutine> RawTimers { get; set; }

        public RawTimerController()
        {
            RawTimers = new Dictionary<string, Coroutine>();
        }

        public IEnumerator RawTimerExecute(string type) 
        {
            var rawObject = _rawStore.RawData[type];

            var rawAmountCap = rawObject.Settings.AmountCap;
            var rawCooldown = rawObject.Settings.Cooldown;

            while (_rawStore.RawData[type].Count < rawAmountCap)
            {
                var countdownValue = rawCooldown;
                while (countdownValue > 0)
                {
                    yield return new WaitForSeconds(1.0f);
                    countdownValue--;
                }

                _rawStore.SetRawListData(type, 1);
            }

            RawTimers.Remove(type);
        }
    }
}
